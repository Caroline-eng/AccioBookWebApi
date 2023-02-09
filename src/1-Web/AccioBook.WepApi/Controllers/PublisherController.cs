using AccioBook.Domain.Entities;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{
    public class PublisherController
    {

        ///// <summary>
        ///// Insere um nova editora no banco.
        ///// </summary>     
        ///// <returns></returns>

        //[HttpPost("insertPublisher")]
        //public async Task<IActionResult> InsertPublisher(PublisherModel publisherArgs)
        //{
        //    var publisher = new Publisher();

        //    publisher.Id = publisherArgs.Id;
        //    publisher.Name = publisherArgs.Name;

        //    publisher = await _publisherService.AddAndSaveAsync(publisher);

        //    if (publisher.Id != default(int))
        //    {
        //        return Ok(publisher);
        //    }

        //    return BadRequest();
        //}

        ///// <summary>
        ///// Deleta uma editora do banco
        ///// </summary>
        ///// <returns></returns>
        //[HttpDelete("deletePublisher")]
        //public async Task<IActionResult> DeletePublisher(PublisherModel publisherArgs)
        //{
        //    var publisher = new Publisher();

        //    publisher.Id = publisherArgs.Id;

        //    try
        //    {
        //        await _publisherService.DeleteAsync(publisher.Id);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        ///// <summary>
        ///// Atualiza uma editora no banco.
        ///// </summary>
        ///// <returns></returns>
        //[HttpPut("updatePublisher")]
        //public async Task<IActionResult> UpdatePublisher(PublisherModel publisherArgs)
        //{
        //    var publisher = new Publisher();

        //    publisher.Id = publisherArgs.Id;
        //    publisher.Name = publisherArgs.Name;

        //    publisher = await _publisherService.UpdateAndSaveAsync(publisher);

        //    if (publisher.Id != default(int))
        //    {
        //        return Ok(publisher);
        //    }

        //    return BadRequest();
        //}

       
    }
}
