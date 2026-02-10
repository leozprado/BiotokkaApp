using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BiotokkaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController(IVendaService vendaService) : ControllerBase
    {
        /// <summary>
        /// Obtém todas as vendas
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var vendas = vendaService.ObterTodos();
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao buscar vendas", Error = ex.Message });
            }
        }

        /// <summary>
        /// Obtém uma venda por ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var venda = vendaService.ObterPorId(id);
                return Ok(venda);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Obtém vendas por período (data início e data fim)
        /// </summary>
        /// <param name="dataInicio">Data inicial (formato: yyyy-MM-dd)</param>
        /// <param name="dataFim">Data final (formato: yyyy-MM-dd)</param>
        [HttpGet("por-periodo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetByPeriodo([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
        {
            try
            {
                if (dataInicio > dataFim)
                {
                    return BadRequest(new { Message = "A data inicial não pode ser maior que a data final" });
                }

                var vendas = vendaService.ObterPorDatas(dataInicio, dataFim);
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao buscar vendas por período", Error = ex.Message });
            }
        }

        /// <summary>
        /// Obtém vendas por cliente
        /// </summary>
        [HttpGet("por-cliente/{clienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetByCliente(int clienteId)
        {
            try
            {
                var vendas = vendaService.ObterPorCliente(clienteId);
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao buscar vendas por cliente", Error = ex.Message });
            }
        }

        /// <summary>
        /// Obtém vendas por produto
        /// </summary>
        [HttpGet("por-produto/{produtoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetByProduto(int produtoId)
        {
            try
            {
                var vendas = vendaService.ObterPorProduto(produtoId);
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao buscar vendas por produto", Error = ex.Message });
            }
        }

        /// <summary>
        /// Cadastra uma nova venda
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] VendaRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var venda = vendaService.Cadastrar(request);
                return CreatedAtAction(nameof(GetById), new { id = venda.Id }, venda);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro ao cadastrar venda", Error = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza uma venda existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, [FromBody] VendaRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var venda = vendaService.Atualizar(id, request);
                return Ok(venda);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Exclui uma venda
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                var venda = vendaService.Excluir(id);
                return Ok(new { Message = "Venda excluída com sucesso", Venda = venda });
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
