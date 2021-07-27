using AutoMapper;
using MonitorGas.GasManagement.Application.Interfaces;
using MonitorGas.GasManagement.Data.Entities;
using MonitorGas.GasManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MonitorGas.GasManagement.Web.Controllers
{
    public class GasSizeController : Controller
    {
        private readonly IGasRepository _gasRepository;
        private readonly IGasSizeRepository _gasSizeRepository;
        private readonly IMapper _mapper;

        public GasSizeController(IGasRepository gasRepository, IGasSizeRepository gasSizeRepository, IMapper mapper)
        {
            _gasRepository = gasRepository;
            _gasSizeRepository = gasSizeRepository;
            _mapper = mapper;
        }
       
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var model = _gasSizeRepository.GetGasSizesWithGas(true);
                var modelToReturn = _mapper.Map<List<GasSizesWithGasModel>>(model);
                return View(modelToReturn);
            }
            catch (Exception)
            {
                return View("Error");
            }

        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create(GasSizesViewModel gasSizesViewModel) 
        {
            try
            {
                var addGas = await _gasSizeRepository.AddAsync(_mapper.Map<GasSize>(gasSizesViewModel));
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }

        }
    }
}