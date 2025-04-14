using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.Interfaces.ISP;
using ISP.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[Authorize(Roles = $"{IspRoles.Admin}")]
[Route("api/[controller]")]
[ApiController]
public class IspController<TEntity, TGetDto, TAddDto, TUpdateDto, TFilter> (IServiceProvider serviceProvider): ControllerBase
    where TEntity : class, IEntity
{
    protected readonly IIspService<TGetDto, TAddDto, TUpdateDto, TFilter> EntityService =
        serviceProvider.GetRequiredService<IIspService<TGetDto, TAddDto, TUpdateDto, TFilter>>();
    
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] PaginationParameters pagination,
        [FromQuery] TFilter filter,
        [FromQuery] SortingParameters sorting)
    {
        var responseDto = await EntityService.GetAllAsync(pagination, filter, sorting);
        return Ok(responseDto);
    }
    
    [HttpGet("count")]
    public async Task<IActionResult> GetCount([FromQuery] TFilter filter)
    {
        var count = await EntityService.GetCountAsync(filter);
        return Ok(count);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var responseDto = await EntityService.GetByIdAsync(id);
        return Ok(responseDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] TAddDto dto)
    {
        var responseDto = await EntityService.AddAsync(dto);
        return Ok(responseDto);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TUpdateDto dto)
    {
        var responseDto = await EntityService.UpdateAsync(id, dto);
        return Ok(responseDto);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await EntityService.DeleteAsync(id);
        return NoContent();
    }
}