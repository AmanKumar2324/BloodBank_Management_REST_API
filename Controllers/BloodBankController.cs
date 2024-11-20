using Microsoft.AspNetCore.Mvc;
using BloodBank_Management_REST_API.Data;
using BloodBank_Management_REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodBank_Management_REST_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodBankController : ControllerBase
    {
        private readonly List<BloodBankEntry> _bloodBankEntries = InmemoryDataStore.BloodBankEntries;

        // GET: api/bloodbank
        [HttpGet]
        public IActionResult GetAllEntries([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            // Validate page and size parameters
            if (page <= 0 || size <= 0)
            {
                return BadRequest(new { Message = "Page and size must be positive integers." });
            }

            // Calculate total items and pages
            int totalItems = _bloodBankEntries.Count;
            int totalPages = (int)Math.Ceiling(totalItems / (double)size);

            // Handle case where page exceeds available pages
            if (page > totalPages && totalItems > 0)
            {
                return BadRequest(new { Message = "Requested page exceeds available pages." });
            }

            // Apply pagination
            var paginatedEntries = _bloodBankEntries
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();

            // Response with metadata
            var response = new
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = size,
                Data = paginatedEntries
            };

            return Ok(response);
        }

        // GET: api/bloodbank/{id}
        [HttpGet("{id}")]
        public IActionResult GetEntryById(Guid id)
        {
            var entry = _bloodBankEntries.FirstOrDefault(e => e.Id == id);

            if (entry == null)
            {
                return NotFound(new { Message = "Entry not found." });
            }

            return Ok(entry);
        }

        // POST: api/bloodbank
        [HttpPost]
        public IActionResult CreateEntry([FromBody] BloodBankEntry newEntry)
        {
            // Input validation
            if (string.IsNullOrEmpty(newEntry.DonorName) ||
                newEntry.Age <= 0 ||
                string.IsNullOrEmpty(newEntry.BloodType) ||
                newEntry.Quantity <= 0 ||
                newEntry.CollectionDate == default ||
                newEntry.ExpirationDate == default)
            {
                return BadRequest(new { Message = "Invalid input. Please check all fields." });
            }

            // Auto-generate Id
            newEntry.Id = Guid.NewGuid();
            _bloodBankEntries.Add(newEntry);

            return CreatedAtAction(nameof(GetEntryById), new { id = newEntry.Id }, newEntry);
        }

        // PUT: api/bloodbank/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEntry(Guid id, [FromBody] BloodBankEntry updatedEntry)
        {
            var existingEntry = _bloodBankEntries.FirstOrDefault(e => e.Id == id);

            if (existingEntry == null)
            {
                return NotFound(new { Message = "Entry not found." });
            }

            // Input validation
            if (string.IsNullOrEmpty(updatedEntry.DonorName) ||
                updatedEntry.Age <= 0 ||
                string.IsNullOrEmpty(updatedEntry.BloodType) ||
                updatedEntry.Quantity <= 0 ||
                updatedEntry.CollectionDate == default ||
                updatedEntry.ExpirationDate == default)
            {
                return BadRequest(new { Message = "Invalid input. Please check all fields." });
            }

            // Update fields
            existingEntry.DonorName = updatedEntry.DonorName;
            existingEntry.Age = updatedEntry.Age;
            existingEntry.BloodType = updatedEntry.BloodType;
            existingEntry.ContactInfo = updatedEntry.ContactInfo;
            existingEntry.Quantity = updatedEntry.Quantity;
            existingEntry.CollectionDate = updatedEntry.CollectionDate;
            existingEntry.ExpirationDate = updatedEntry.ExpirationDate;
            existingEntry.Status = updatedEntry.Status;

            return Ok(existingEntry);
        }

        // DELETE: api/bloodbank/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEntry(Guid id)
        {
            var entry = _bloodBankEntries.FirstOrDefault(e => e.Id == id);

            if (entry == null)
            {
                return NotFound(new { Message = "Entry not found." });
            }

            _bloodBankEntries.Remove(entry);

            return NoContent();
        }
    }
}
