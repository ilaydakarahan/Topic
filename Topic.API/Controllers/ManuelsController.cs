﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.DTOs.ManuelDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ManuelsController : ControllerBase
	{
		private readonly IManuelService _manuelService;
		private readonly IMapper _mapper;

		public ManuelsController(IManuelService manuelService, IMapper mapper)
		{
			_manuelService = manuelService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ManuelList()
		{
			var values = _manuelService.TGetList();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public IActionResult GetBYId(int id)
		{
			var values = _manuelService.TGetById(id);
			return Ok(values);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteManuel(int id)
		{
			_manuelService.TDelete(id);
			return Ok("Silindi");
		}

		[HttpPost]
		public IActionResult CreateManuel(CreateManuelDto createManuelDto)
		{
			var newManuel = _mapper.Map<Manuel>(createManuelDto);
			_manuelService.TCreate(newManuel);
			return Ok(newManuel);	
		}

		[HttpPut]
		public IActionResult UpdateManuel(UpdateManuelDto updateManuelDto)
		{
			var updateManuel = _mapper.Map<Manuel>(updateManuelDto);
			_manuelService.TUpdate(updateManuel);
			return Ok("Manuel Güncellendi.");
		}

	}
}
