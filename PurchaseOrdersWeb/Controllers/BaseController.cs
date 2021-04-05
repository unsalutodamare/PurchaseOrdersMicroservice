using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PurchaseOrders.Data;
using PurchaseOrders.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrdersWeb.Controllers
{
    [ApiController]
    public abstract class BaseController<TEntity> : Controller
    where TEntity : class, IBase
    {
        protected readonly IBaseService<TEntity> _service;
        private readonly ILogger<TEntity> _logger;
        protected BaseController([NotNull] IBaseService<TEntity> service, ILogger<TEntity> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TEntity entity)
        {
            Guid id = Guid.NewGuid();
            try
            {
                entity = await _service.CreateAsync(entity);

                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "|" + id + "|", ex.Message);
                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ReadAsync(int id)
        {
            Guid guid = Guid.NewGuid();
            try
            {
                
                var entity = await _service.ReadAsync(id);

                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "|" + guid + "|", ex.Message);
                return NotFound();
            }
        }

        [HttpGet("findall")]
        public async Task<IActionResult> GetAllAsync()
        {
            Guid id = Guid.NewGuid();
            var entities = await _service.GetAllAsync().ToListAsync();
            try
            {
                return Ok(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "|" + id + "|", ex.Message);
                return NotFound();
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdatePartialAsync(int id, [FromBody] JsonPatchDocument<TEntity> patchEntity)
        {
            Guid guid = Guid.NewGuid();
            try
            {
                
                var entity = await _service.ReadAsync(id, false);

                patchEntity.ApplyTo(entity, ModelState);
                entity = await _service.UpdateAsync(id, entity);

                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "|" + guid + "|", ex.Message);
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Guid guid = Guid.NewGuid();
            try
            {
                var entity = await _service.ReadAsync(id);

                await _service.DeleteAsync(id);

                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "|" + guid + "|", ex.Message);
                return NotFound();
            }
        }
    }
}
