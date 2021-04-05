using Microsoft.AspNetCore.Mvc;
using PurchaseOrders.Data;
using PurchaseOrders.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PurchaseOrdersWeb.Controllers
{
    [Route("api/purchaseorder")]
    public class PurchaseOrderController : BaseController<PurchaseOrder>
    {
        private IPurchaseOrderService _purchaseOrderService;
        private readonly ILogger<PurchaseOrder> _logger;
        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService, ILogger<PurchaseOrder> logger) : base(purchaseOrderService, logger)
        {
            _purchaseOrderService = purchaseOrderService;
            _logger = logger;
        }

        [HttpGet("searchStatus/{keyword}")]
        public async Task<IActionResult> SearchStatusAsync(string keyword)
        {
            Guid id = Guid.NewGuid();
            var result = _purchaseOrderService.SearchStatusAsync(keyword);
            try
            {
                _logger.LogInformation("|" + id + "|REQUESTWS: " + keyword + "|RESPONSEWS: " + result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "|" + id + "|", ex.Message);
                return BadRequest();

            }
        }

        [HttpGet("searchTotal/{min}/{max}")]
        public async Task<IActionResult> SearchTotalAsync(double min, double max)
        {
            Guid id = Guid.NewGuid();
            var result = _purchaseOrderService.SearchTotalAsync(min, max);
            try
            {
                _logger.LogInformation("|" + id + "|REQUESTWS: " + min + max + "|RESPONSEWS: " + result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "|" + id + "|", ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("searchBetweenDate/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> SearchBetweenDateAsync(DateTime dateFrom, DateTime dateTo)
        {
            Guid id = Guid.NewGuid();
            var result = _purchaseOrderService.SearchBetweenDateAsync(dateFrom, dateTo);
            try
            {
                _logger.LogInformation("|" + id + "|REQUESTWS: " + dateFrom + dateTo + "|RESPONSEWS: " + result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "|" + id + "|", ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("searchByProductName/{name}")]
        public async Task<IActionResult> SearchByProductAsync(string productName)
        {
            Guid id = Guid.NewGuid();
            var result = _purchaseOrderService.SearchByProductAsync(productName);
            try
            {
                _logger.LogInformation("|" + id + "|REQUESTWS: " + productName + "|RESPONSEWS: " + result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "|" + id + "|", ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("searchByClientName/{name}")]
        public async Task<IActionResult> SearchByClientNameAsync(string name)
        {
            Guid id = Guid.NewGuid();
            var result = _purchaseOrderService.SearchByClientNameAsync(name);
            try
            {
                _logger.LogInformation("|" + id + "|REQUESTWS: " + name + "|RESPONSEWS: " + result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "|" + id + "|", ex.Message);
                return BadRequest();
            }
        }
    }
}
