using ActionHistoryApp.API.Persistence;
using ActionHistoryApp.API.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActionHistoryApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionsController : ControllerBase
    {
        private readonly BlazingActionsContext _context;
        private readonly ILogger<ActionsController> _logger;

        public ActionsController(BlazingActionsContext context, ILogger<ActionsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/actions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActionItem>>> GetAction()
        {
            try
            {
                var actions = await _context.Actions
                    .OrderByDescending(a => a.WhenDid)
                    .ToListAsync();
                return Ok(actions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении действий");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActionItem>> GetAction(int  id)
        {
            try
            {
                var action = await _context.Actions.FindAsync(id);
                
                if(action == null)
                {
                    return NotFound();
                }
                return Ok(action);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении действия {id}", id);
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        // POST: api/actions
        [HttpPost] 
        public async Task<ActionResult<ActionItem>> CreateAction(ActionItem action)
        {
            try
            {
                // Валидация
                if (string.IsNullOrWhiteSpace(action.DataBaseName) ||
                    string.IsNullOrWhiteSpace(action.WhatDid) ||
                    string.IsNullOrWhiteSpace(action.WhoDid))
                {
                    return BadRequest("Все поля обязательны для заполнения");
                }

                // Убеждаемся что Id не установлен (будет авто-инкремент)
                action.Id = 0;

                //// Добавляем запись
                _context.Actions.Add(action);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAction), new { id = action.Id }, action);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при сохронании");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        // PUT: api/actions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAction(int id, ActionItem action)
        {
            if (id != action.Id)
            {
                return BadRequest();
            }
            try
            {
                _context.Entry(action).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ActionExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления действия {Id}", id);
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        // DELETE: api/actions/{id}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAction(int id)
        {
            try
            {
                var action = await _context.Actions.FindAsync(id);
                if (action == null)
                {
                    return NotFound();
                }

                _context.Actions.Remove(action);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления действия {Id}", id);
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        private async Task<bool> ActionExists(int id)
        {
            return await _context.Actions.AnyAsync(_ => _.Id == id);
        }
    }
}
