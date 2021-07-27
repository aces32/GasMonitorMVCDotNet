using AutoMapper;
using MonitorGas.GasManagement.Application.Interfaces;
using MonitorGas.GasManagement.Web.Models.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MonitorGas.GasManagement.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index() 
        {
            var model = new SelectedMonthViewModel { OrderDate = DateTime.Now };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(SelectedMonthViewModel selectedMonth)
        {
            try
            {
                var modelToReturn = await _orderRepository.GetPagedOrdersForMonth(selectedMonth.OrderDate, 1, 5);
                var selectedViewToReturn = new SelectedMonthViewModel { Sales = _mapper.Map<List<OrdersForMonthListViewModel>>(modelToReturn) };

                return View(selectedViewToReturn);
            }
            catch (Exception)
            {
                return View("Error");
            }

        }

    }
}