using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioLibary.Model;
using DesafioLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class PlaceHolderController : ControllerBase
    {
        private readonly  IRepository _repo;
        public PlaceHolderController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("BaixarDados")]
        public async Task<IActionResult> BaixarDados()
        {
            List<User> users = new List<User>();

            users = await _repo.GetDados();
            return Ok(users);
        }

       
        [HttpGet("SalvarDados")]
        public async Task<IActionResult> SalvarDados()
        {
            try
            {
                var user = await _repo.GetDados();
                var resp = await _repo.FilterBySuite(user);
              
                _repo.AddRows(resp);

                if (await _repo.SaveChangeAsync())
                {
                    return Ok(resp);
                }            
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Server Error, {e.Message}");
            }

            return BadRequest();
        }
    }
}