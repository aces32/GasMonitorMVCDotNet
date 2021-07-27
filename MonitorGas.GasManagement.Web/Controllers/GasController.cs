using AutoMapper;
using MonitorGas.GasManagement.Application.Interfaces;
using MonitorGas.GasManagement.Data.Entities;
using MonitorGas.GasManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MonitorGas.GasManagement.Web.Controllers
{
    public class GasController : Controller
    {
        private readonly IGasRepository _gasRepository;
        private readonly IGasSizeRepository _gasSizeRepository;
        private readonly IMapper _mapper;

        public GasController(IGasRepository gasRepository, IGasSizeRepository gasSizeRepository, IMapper mapper)
        {
            _gasRepository = gasRepository;
            _gasSizeRepository = gasSizeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = await _gasRepository.ListAllAsync();

            return View(_mapper.Map<IReadOnlyList<GasListViewModel>>(model));
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _gasRepository.GetByIdAsync(id);
            if (model == null)
            {
                return View("NotFound");
            }
            var modelToReturn = _mapper.Map<GasDetailsViewModel>(model);

            ///Get Gas Size
            var gasSizes = await _gasSizeRepository.GetByIdAsync(modelToReturn.GasSizeID);
            modelToReturn.GasSize = _mapper.Map<GasSizesViewModel>(gasSizes);

            return View(modelToReturn);
        }

        public async Task<ActionResult> Create() 
        {
            var allgasSizesForDropDwn = await _gasSizeRepository.ListAllAsync();
            ViewBag.AllGasSizes = _mapper.Map<IReadOnlyList<GasSizesViewModel>>(allgasSizesForDropDwn);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(GasDetailsViewModel gasDetailsViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var selectedGasSizeID = Request.Form["GasSizeID"];
                    gasDetailsViewModel.GasSizeID = Guid.Parse(Request.Form["SizeInKg"]);
                    await _gasRepository.AddAsync(_mapper.Map<Gas>(gasDetailsViewModel));
                    TempData["Message"] = "You have updated the Gas cylinder information";
                    return RedirectToAction("Details", new { id = gasDetailsViewModel.GasID });
                }
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _gasRepository.GetByIdAsync(id);          
            if (model == null)
            {
                return View("NotFound");
            }

            var modelToReturn = _mapper.Map<GasDetailsViewModel>(model);
            
            ///Get Gas Size
            var gasSizes = await _gasSizeRepository.GetByIdAsync(modelToReturn.GasSizeID);

            /// All Gas Size for DropDown
            var allgasSizesForDropDwn = await _gasSizeRepository.ListAllAsync();

            modelToReturn.GasSize = _mapper.Map<GasSizesViewModel>(gasSizes);
            ViewBag.AllGasSizes = _mapper.Map<IReadOnlyList<GasSizesViewModel>>(allgasSizesForDropDwn);
            return View(modelToReturn);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(GasDetailsViewModel gasDetailsViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var selectedGasSizeID = Request.Form["GasSizeID"];
                    gasDetailsViewModel.GasSizeID = Guid.Parse(Request.Form["SizeInKg"]);

                    await _gasRepository.UpdateAsync(_mapper.Map<Gas>(gasDetailsViewModel));
                    TempData["Message"] = "You have updated the Gas cylinder information";
                    return RedirectToAction("Details", new { id = gasDetailsViewModel.GasID });
                }
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var model = await _gasRepository.GetByIdAsync(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(_mapper.Map<GasDetailsViewModel>(model));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id, GasDetailsViewModel gasDetailsViewModel)
        {
            try
            {
                var deletedata = new GasDetailsViewModel { GasID = id };
                await _gasRepository.DeleteAsync(_mapper.Map<Gas>(deletedata));
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }
    }
}
