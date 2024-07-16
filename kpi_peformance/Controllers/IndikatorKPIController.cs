using LogKPI.Data;
using LogKPI.Models;
using System.Linq;
using System.Web.Mvc;
using System;
using System.Web;
using OfficeOpenXml;
using System.Collections.Generic;

namespace LogKPI.Controllers
{
    public class IndikatorKPIController : Controller
    {
        // GET: kpi
        private readonly KPIContext db = new KPIContext();
        public ActionResult Dashboard(DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!fromDate.HasValue || !toDate.HasValue)
            {
                // Set default date range if fromDate or toDate is not provided
                fromDate = DateTime.Now.Date.AddMonths(-2); // Default to one month ago
                toDate = DateTime.Now.Date;  // Default to today
            }
            var dataKpi = db.TB_KPIs.OrderBy(date => date.Ship_date).ToList();
            var filteredDataKpi = dataKpi.Where(d => d.Ship_date >= fromDate && d.Ship_date <= toDate).ToList();
            dataKpi = filteredDataKpi;

            var chartFilter = filteredDataKpi;
            ViewBag.ChartLabels = chartFilter.Select(date => date.Ship_date.ToString("dd MMM")).ToList();
            ViewBag.ChartDe = chartFilter.Select(date => date.DE).ToList();
            ViewBag.ChartHscode = chartFilter.Select(date => date.HS_CodeErr).ToList();
            ViewBag.ChartCoErr = chartFilter.Select(date => date.CO_Err).ToList();
            ViewBag.ChartVal = chartFilter.Select(date => date.Val_Err).ToList();
            ViewBag.ChartQty = chartFilter.Select(date => date.Quantity).ToList();
            ViewBag.ChartSumOP = chartFilter.Select(date => date.OP).ToList();
            ViewBag.ChartNumBilLand = chartFilter.Select(date => date.Num_BL).ToList();

            return View(dataKpi);
        }

        public ActionResult IndexData(DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!fromDate.HasValue || !toDate.HasValue)
            {
                // Set default date range if fromDate or toDate is not provided
                fromDate = DateTime.Now.Date.AddMonths(-2); // Default to one month ago
                toDate = DateTime.Now.Date;  // Default to today
            }

            var dataKpi = db.TB_KPIs.OrderBy(date => date.Ship_date).ToList();
            var filteredDataKpi = dataKpi.Where(d => d.Ship_date >= fromDate && d.Ship_date <= toDate).ToList();
            dataKpi = filteredDataKpi;

            // Set ViewBag values for input field display
            ViewBag.ToDate = toDate.Value.ToString("yyyy-MM-dd");
            ViewBag.FromDate = fromDate.Value.ToString("yyyy-MM-dd");

            var data = new CombineModel
            {
                ListKPI = filteredDataKpi, // Use the filtered data for display
                CreateKPI = new TB_KPI()
            };

            return View(data);
        }

        //View Chart Description Error
        public ActionResult DE_IndexData(DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!fromDate.HasValue || !toDate.HasValue)
            {
                // Set default date range if fromDate or toDate is not provided
                fromDate = DateTime.Now.Date.AddMonths(-2); // Default to one month ago
                toDate = DateTime.Now.Date;  // Default to today
            }

            var dataKpi = db.TB_KPIs.OrderBy(date => date.Ship_date).ToList();
            var filteredDataKpi = dataKpi.Where(d => d.Ship_date >= fromDate && d.Ship_date <= toDate).ToList();
            dataKpi = filteredDataKpi;

            var chartData = filteredDataKpi;
            ViewBag.ChartLabels = chartData.Select(date => date.Ship_date.ToString("dd MMM")).ToList();
            ViewBag.ChartDe = chartData.Select(de => de.DE).ToList();

            // Set ViewBag values for input field display
            ViewBag.ToDate = toDate.Value.ToString("yyyy-MM-dd");
            ViewBag.FromDate = fromDate.Value.ToString("yyyy-MM-dd");

            var data = new CombineModel
            {
                ListKPI = dataKpi,
                CreateKPI = new TB_KPI()
            };

            return View(data);
        }

        //View Chart HS Code Error
        public ActionResult HSCode_IndexData(DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!fromDate.HasValue || !toDate.HasValue)
            {
                // Set default date range if fromDate or toDate is not provided
                fromDate = DateTime.Now.Date.AddMonths(-2); // Default to one month ago
                toDate = DateTime.Now.Date;  // Default to today
            }

            var dataKpi = db.TB_KPIs.OrderBy(date => date.Ship_date).ToList();
            var filteredDataKpi = dataKpi.Where(d => d.Ship_date >= fromDate && d.Ship_date <= toDate).ToList();
            dataKpi = filteredDataKpi;

            var chartData = filteredDataKpi;
            ViewBag.ChartLabels = chartData.Select(date => date.Ship_date.ToString("dd MMM")).ToList();
            ViewBag.ChartHscode = chartData.Select(de => de.HS_CodeErr).ToList();

            // Set ViewBag values for input field display
            ViewBag.ToDate = toDate.Value.ToString("yyyy-MM-dd");
            ViewBag.FromDate = fromDate.Value.ToString("yyyy-MM-dd");

            var data = new CombineModel
            {
                ListKPI = dataKpi,
                CreateKPI = new TB_KPI()
            };
            return View(data);
        }

        //View Chart HS Code Error
        public ActionResult Qty_IndexData(DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!fromDate.HasValue || !toDate.HasValue)
            {
                // Set default date range if fromDate or toDate is not provided
                fromDate = DateTime.Now.Date.AddMonths(-2); // Default to one month ago
                toDate = DateTime.Now.Date;  // Default to today
            }

            var dataKpi = db.TB_KPIs.OrderBy(date => date.Ship_date).ToList();
            var filteredDataKpi = dataKpi.Where(d => d.Ship_date >= fromDate && d.Ship_date <= toDate).ToList();
            dataKpi = filteredDataKpi;

            var chartData = filteredDataKpi;
            ViewBag.ChartLabels = chartData.Select(date => date.Ship_date.ToString("dd MMM")).ToList();
            ViewBag.ChartQty = chartData.Select(de => de.Quantity).ToList();

            // Set ViewBag values for input field display
            ViewBag.ToDate = toDate.Value.ToString("yyyy-MM-dd");
            ViewBag.FromDate = fromDate.Value.ToString("yyyy-MM-dd");

            var data = new CombineModel
            {
                ListKPI = dataKpi,
                CreateKPI = new TB_KPI()
            };
            return View(data);
        }

        //View Chart CoO Error
        public ActionResult CoO_IndexData(DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!fromDate.HasValue || !toDate.HasValue)
            {
                // Set default date range if fromDate or toDate is not provided
                fromDate = DateTime.Now.Date.AddMonths(-2); // Default to one month ago
                toDate = DateTime.Now.Date;  // Default to today
            }

            var dataKpi = db.TB_KPIs.OrderBy(date => date.Ship_date).ToList();
            var filteredDataKpi = dataKpi.Where(d => d.Ship_date >= fromDate && d.Ship_date <= toDate).ToList();
            dataKpi = filteredDataKpi;

            var chartData = filteredDataKpi;
            ViewBag.ChartLabels = chartData.Select(date => date.Ship_date.ToString("dd MMM")).ToList();
            ViewBag.ChartCoErr = chartData.Select(de => de.CO_Err).ToList();

            // Set ViewBag values for input field display
            ViewBag.ToDate = toDate.Value.ToString("yyyy-MM-dd");
            ViewBag.FromDate = fromDate.Value.ToString("yyyy-MM-dd");

            var data = new CombineModel
            {
                ListKPI = dataKpi,
                CreateKPI = new TB_KPI()
            };
            return View(data);
        }

        //View Chart CoO Error
        public ActionResult Val_IndexData(DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!fromDate.HasValue || !toDate.HasValue)
            {
                // Set default date range if fromDate or toDate is not provided
                fromDate = DateTime.Now.Date.AddMonths(-2); // Default to one month ago
                toDate = DateTime.Now.Date;  // Default to today
            }

            var dataKpi = db.TB_KPIs.OrderBy(date => date.Ship_date).ToList();
            var filteredDataKpi = dataKpi.Where(d => d.Ship_date >= fromDate && d.Ship_date <= toDate).ToList();
            dataKpi = filteredDataKpi;

            var chartData = filteredDataKpi;
            ViewBag.ChartLabels = chartData.Select(date => date.Ship_date.ToString("dd MMM")).ToList();
            ViewBag.ChartVal = chartData.Select(de => de.Val_Err).ToList();

            // Set ViewBag values for input field display
            ViewBag.ToDate = toDate.Value.ToString("yyyy-MM-dd");
            ViewBag.FromDate = fromDate.Value.ToString("yyyy-MM-dd");

            var data = new CombineModel
            {
                ListKPI = dataKpi,
                CreateKPI = new TB_KPI()
            };
            return View(data);
        }

        //View Chart CoO Error
        public ActionResult Ovr_IndexData(DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!fromDate.HasValue || !toDate.HasValue)
            {
                // Set default date range if fromDate or toDate is not provided
                fromDate = DateTime.Now.Date.AddMonths(-2); // Default to one month ago
                toDate = DateTime.Now.Date;  // Default to today
            }

            var dataKpi = db.TB_KPIs.OrderBy(date => date.Ship_date).ToList();
            var filteredDataKpi = dataKpi.Where(d => d.Ship_date >= fromDate && d.Ship_date <= toDate).ToList();
            dataKpi = filteredDataKpi;

            var chartData = filteredDataKpi;
            ViewBag.ChartLabels = chartData.Select(date => date.Ship_date.ToString("dd MMM")).ToList();
            ViewBag.ChartSumOP = chartData.Select(de => de.OP).ToList();

            // Set ViewBag values for input field display
            ViewBag.ToDate = toDate.Value.ToString("yyyy-MM-dd");
            ViewBag.FromDate = fromDate.Value.ToString("yyyy-MM-dd");

            var data = new CombineModel
            {
                ListKPI = dataKpi,
                CreateKPI = new TB_KPI()
            };
            return View(data);
        }

        //View Chart CoO Error
        public ActionResult NumBill_IndexData(DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!fromDate.HasValue || !toDate.HasValue)
            {
                // Set default date range if fromDate or toDate is not provided
                fromDate = DateTime.Now.Date.AddMonths(-2); // Default to one month ago
                toDate = DateTime.Now.Date;  // Default to today
            }

            var dataKpi = db.TB_KPIs.OrderBy(date => date.Ship_date).ToList();
            var filteredDataKpi = dataKpi.Where(d => d.Ship_date >= fromDate && d.Ship_date <= toDate).ToList();
            dataKpi = filteredDataKpi;

            var chartData = filteredDataKpi;
            ViewBag.ChartLabels = chartData.Select(date => date.Ship_date.ToString("dd MMM")).ToList();
            ViewBag.ChartNumBilLand = chartData.Select(de => de.Num_BL).ToList();

            // Set ViewBag values for input field display
            ViewBag.ToDate = toDate.Value.ToString("yyyy-MM-dd");
            ViewBag.FromDate = fromDate.Value.ToString("yyyy-MM-dd");

            var data = new CombineModel
            {
                ListKPI = dataKpi,
                CreateKPI = new TB_KPI()
            };
            return View(data);
        }

        /*INSERT ERROR INDIKATOR FOR KPI*/
        [HttpPost]
        public ActionResult PostCreate(CombineModel combine)
        {
            if (ModelState.IsValid)
            {
                // Calculate KPIs (assuming calculations are already defined in your code)
                combine.CreateKPI.Sum_Err = combine.CreateKPI.DE + combine.CreateKPI.HS_CodeErr + combine.CreateKPI.CO_Err + combine.CreateKPI.Quantity + combine.CreateKPI.Val_Err;
                combine.CreateKPI.CF = combine.CreateKPI.Num_BL * 6;
                combine.CreateKPI.TF = combine.CreateKPI.CF;
                combine.CreateKPI.OP = ((combine.CreateKPI.TF - combine.CreateKPI.Sum_Err) / combine.CreateKPI.CF) * 100;
                combine.CreateKPI.Input_Date = DateTime.Now;

                // Save data to database
                db.TB_KPIs.Add(combine.CreateKPI);
                db.SaveChanges();
                
                TempData["alertMessage"] = "Data successfully added";
                return RedirectToAction("IndexData");
            }

            // Return JSON indicating error (optional)
            return RedirectToAction("PostCreate", combine);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // Temukan data yang akan dihapus dari database
                var dataUser = db.TB_KPIs.Find(id);
                if (dataUser != null)
                {
                    db.TB_KPIs.Remove(dataUser);
                    db.SaveChanges();
                }
                return RedirectToAction("IndexData"); // Redirect kembali ke tampilan Index setelah berhasil menghapus data
            }
            catch (Exception)
            {
                // Handle Error if this failed to deleted
                return RedirectToAction("IndexData"); // Anda dapat memilih tindakan yang sesuai jika terjadi kesalahan
            }
        }

        //Data input method from excel to speed up data input time
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    //declaration tabel data
                    var dataKPI = db.TB_KPIs.ToList();
                    var combine = new CombineModel //combine multiple models
                    {
                        ListKPI = dataKPI,
                        CreateKPI = new TB_KPI()
                    };

                    // Set the license context (replace with your choice)
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Or LicenseContext.Commercial
                    var worksheet = package.Workbook.Worksheets[0];
                    using (var db = new KPIContext())
                    {
                        //looping value excel file
                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                        {
                            try
                            {
                                //inisialisasi row pada excel
                                combine.CreateKPI.Ship_date = DateTime.Parse(worksheet.Cells[row, 1].Text.Trim());
                                combine.CreateKPI.Num_BL = int.Parse(worksheet.Cells[row, 2].Text.Trim());
                                combine.CreateKPI.Num_Dec = int.Parse(worksheet.Cells[row, 3].Text.Trim());
                                combine.CreateKPI.DE = int.Parse(worksheet.Cells[row, 4].Text.Trim());
                                combine.CreateKPI.HS_CodeErr = int.Parse(worksheet.Cells[row, 5].Text.Trim());
                                combine.CreateKPI.CO_Err = int.Parse(worksheet.Cells[row, 6].Text.Trim());
                                combine.CreateKPI.Quantity = int.Parse(worksheet.Cells[row, 7].Text.Trim());
                                combine.CreateKPI.Val_Err = int.Parse(worksheet.Cells[row, 8].Text.Trim());

                                //calculated total error
                                combine.CreateKPI.Sum_Err = combine.CreateKPI.DE + combine.CreateKPI.HS_CodeErr + combine.CreateKPI.CO_Err + combine.CreateKPI.Quantity + combine.CreateKPI.Val_Err;
                                //calculated target
                                combine.CreateKPI.CF = combine.CreateKPI.Num_BL * 6;
                                combine.CreateKPI.TF = combine.CreateKPI.CF;
                                //calculated percentage 
                                combine.CreateKPI.OP = ((combine.CreateKPI.TF - combine.CreateKPI.Sum_Err) / combine.CreateKPI.CF) * 100;
                                combine.CreateKPI.Input_Date = DateTime.Now;

                                // saving data to database
                                db.TB_KPIs.Add(combine.CreateKPI);
                                db.SaveChanges();
                                TempData["alertMessage"] = "Success import data excel";
                            }
                            catch(FormatException ex)
                            {
                                combine.CreateKPI.Ship_date = DateTime.MinValue;
                                TempData["Error"] = "invalid format in the excel file" + ex.Message;
                            }                            
                        }
                        return RedirectToAction("IndexData", combine);
                    }
                }
            }            
            return View();
        }   
    }
}