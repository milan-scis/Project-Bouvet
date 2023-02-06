using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BouvetTask.Models;
using BouvetTask.Services.Interfaces;
using BouvetTask.Dtos.Epic;

namespace BouvetTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EpicController : ControllerBase
    {
        private readonly IEpicService _epicService;
        private readonly string _errorMessage = "There was a problem with processing the request.";

        public EpicController(IEpicService epicService)
        {
            _epicService = epicService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetEpicDto>>> Get()
        {
            try
            { 
                return Ok(await _epicService.GetAllEpics());
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }

        [HttpGet("{epicId}")]
        public async Task<ActionResult<GetEpicDto>> Get(int epicId)
        {
            try
            {
                return Ok(await _epicService.GetEpicById(epicId));
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<string>> Add(AddEpicDto newEpic)
        {
            try
            {
                return Ok(await _epicService.AddEpic(newEpic));
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<string>> Update(UpdateEpicDto updatedEpic)
        {
            try
            {
                return Ok(await _epicService.UpdateEpic(updatedEpic));
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }

        [HttpDelete("{epicId}")]
        public async Task<ActionResult<string>> Delete(int epicId)
        {
            try
            {
                return Ok(await _epicService.DeleteEpicByID(epicId));
            }
            catch
            {
                return BadRequest(_errorMessage);
            }
        }
    }
}
