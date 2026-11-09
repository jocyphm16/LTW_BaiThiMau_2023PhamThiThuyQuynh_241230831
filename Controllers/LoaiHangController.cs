
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhamThiThuyQuynh_241230831.Models;

public class LoaiHangController : Controller
{
    private readonly QlhangHoaContext _context;

    public LoaiHangController(QlhangHoaContext context)
    {
        _context = context;
    }

    // GET: LOAIHANGS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.LoaiHangs.ToListAsync());
    }

    // GET: LOAIHANGS/Details/5
    public async Task<IActionResult> Details(int? maloai)
    {
        if (maloai == null)
        {
            return NotFound();
        }

        var loaihang = await _context.LoaiHangs
            .FirstOrDefaultAsync(m => m.MaLoai == maloai);
        if (loaihang == null)
        {
            return NotFound();
        }

        return View(loaihang);
    }

    // GET: LOAIHANGS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LOAIHANGS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaLoai,TenLoai,HangHoas")] LoaiHang loaihang)
    {
        if (ModelState.IsValid)
        {
            _context.Add(loaihang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(loaihang);
    }

    // GET: LOAIHANGS/Edit/5
    public async Task<IActionResult> Edit(int? maloai)
    {
        if (maloai == null)
        {
            return NotFound();
        }

        var loaihang = await _context.LoaiHangs.FindAsync(maloai);
        if (loaihang == null)
        {
            return NotFound();
        }
        return View(loaihang);
    }

    // POST: LOAIHANGS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? maloai, [Bind("MaLoai,TenLoai,HangHoas")] LoaiHang loaihang)
    {
        if (maloai != loaihang.MaLoai)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(loaihang);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiHangExists(loaihang.MaLoai))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(loaihang);
    }

    // GET: LOAIHANGS/Delete/5
    public async Task<IActionResult> Delete(int? maloai)
    {
        if (maloai == null)
        {
            return NotFound();
        }

        var loaihang = await _context.LoaiHangs
            .FirstOrDefaultAsync(m => m.MaLoai == maloai);
        if (loaihang == null)
        {
            return NotFound();
        }

        return View(loaihang);
    }

    // POST: LOAIHANGS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? maloai)
    {
        var loaihang = await _context.LoaiHangs.FindAsync(maloai);
        if (loaihang != null)
        {
            _context.LoaiHangs.Remove(loaihang);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LoaiHangExists(int? maloai)
    {
        return _context.LoaiHangs.Any(e => e.MaLoai == maloai);
    }
}
