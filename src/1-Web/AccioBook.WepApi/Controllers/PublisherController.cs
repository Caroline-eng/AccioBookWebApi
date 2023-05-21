using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.Domain.Services;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{

    /// <summary>
    /// AccioBook documentação  
    /// </summary>
    [Route("publisher")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        /// <summary>
        /// Insere uma editora no banco.
        /// </summary>     
        /// <returns></returns>

        [HttpPost("insert")]
        public async Task<IActionResult> Insert(PublisherModel publisherArgs)
        {
            var publisher = new Publisher();
            
            publisher.Name = publisherArgs.Name;

            publisher = await _publisherService.AddAndSaveAsync(publisher);

            if (publisher.Id != default(int))
            {
                return Ok(publisher);
            }

            return BadRequest();
        }

        /// <summary>
        /// Deleta uma editora do banco
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{publisherId}")]
        public async Task<IActionResult> DeletePublisher(Int64 publisherId)
        {         

            try
            {
                await _publisherService.DeleteAsync(publisherId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza uma editora no banco.
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/{publisherId}")]
        public async Task<IActionResult> UpdatePublisher(Int64 publisherId, PublisherModel publisherArgs)
        {
            var publisher = await _publisherService.GetAsync(publisherId);

            if (publisher == null)
            {
                return NotFound();
            }

            publisher.Name = publisherArgs.Name;


            await _publisherService.UpdateAndSaveAsync(publisher);

            return Ok(publisher);

        }


        /// <summary>
        /// Retorna as últimas 100 editoras 
        /// </summary>
        /// <returns></returns>
        [HttpGet("all-last-100")]
        public async Task<IActionResult> GetPublishersLast100()
        {
            try
            {
                var publisher = await _publisherService.GetLastPublishersTop100();
                return Ok(publisher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna toda lista de Editoras
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetPublisher()
        {
            try
            {
                var publisher = await _publisherService.GetAllAsync();
                return Ok(publisher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///Pesquisa por editora
        /// </summary>
        /// <returns></returns>
        [HttpGet("search/{publisherName}")]
        public async Task<IActionResult> GetPublisherByName(string publisherName)
        {
            try
            {
                var author = await _publisherService.GetPublisherByNameAsync(publisherName);
                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
