/**
 * EShopApp Luxury — app.js
 * Vanilla JS. Backend geçişinde API çağrılarına kolayca dönüştürülür.
 */

// ==========================================================================
// 1. Ürün Veri Seti (8 Luxury Ürün)
// ==========================================================================
const sampleProducts = [
  {
    id: 1,
    name: "Kablosuz Gürültü Engelleyici Kulaklık Pro",
    category: "elektronik", categoryName: "Elektronik",
    price: 4299.90, oldPrice: 5299.00,
    image: "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=700&auto=format&fit=crop&q=80",
    description: "Aktif gürültü engelleme teknolojisiyle beraber 40 saate varan pil ömrü, Hi-Res Audio sertifikalı 40mm titanyum kaplama sürücüler ve çevresel ses passthrough modu sunmaktadır.",
    stock: 12, featured: true, isNew: false,
    rating: 4.8, reviews: 214
  },
  {
    id: 2,
    name: "Akıllı Saat Ultra — Titanyum Kasa",
    category: "elektronik", categoryName: "Elektronik",
    price: 7999.00, oldPrice: 9499.00,
    image: "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=700&auto=format&fit=crop&q=80",
    description: "Titanyum kasa, ultra ince Sapphire cam ekran, daima açık AMOLED panel, dahili ECG sensörü, GPS + GLONASS ve 18 günlük pil ömrü.",
    stock: 6, featured: true, isNew: true,
    rating: 4.9, reviews: 89
  },
  {
    id: 3,
    name: "Mekanik RGB Oyuncu Klavyesi TKL",
    category: "elektronik", categoryName: "Elektronik",
    price: 2850.00, oldPrice: 3490.00,
    image: "https://images.unsplash.com/photo-1587829741301-dc798b83add3?w=700&auto=format&fit=crop&q=80",
    description: "Hot-swap destekli PCB, çift katmanlı PBT keycap, per-key RGB aydınlatma, CNC alüminyum üst kasa ve gasket montaj sistemi.",
    stock: 15, featured: true, isNew: false,
    rating: 4.6, reviews: 173
  },
  {
    id: 4,
    name: "Ergonomik Kablosuz Optik Mouse",
    category: "elektronik", categoryName: "Elektronik",
    price: 1480.00, oldPrice: 1799.00,
    image: "https://images.unsplash.com/photo-1527864550417-7fd91fc51a46?w=700&auto=format&fit=crop&q=80",
    description: "25.600 DPI optik sensör, 95 saate varan pil ömrü, sessiz manyetik tıklama mekanizması, ağırlık sistemi ve paraşüt örgülü USB-C kablo.",
    stock: 20, featured: false, isNew: false,
    rating: 4.5, reviews: 312
  },
  {
    id: 5,
    name: "Full-Grain Deri Premium Sırt Çantası",
    category: "aksesuar", categoryName: "Aksesuar",
    price: 3950.00, oldPrice: 4750.00,
    image: "https://images.unsplash.com/photo-1553062407-98eeb64c6a62?w=700&auto=format&fit=crop&q=80",
    description: "İtalyan tabakhanelerinden temin edilen full-grain deri, pirinç donanım, YKK fermuar, 15.6\" laptop bölmesi ve ömür boyu garanti.",
    stock: 5, featured: true, isNew: false,
    rating: 4.9, reviews: 56
  },
  {
    id: 6,
    name: "Polarize Titanyum Güneş Gözlüğü",
    category: "aksesuar", categoryName: "Aksesuar",
    price: 2290.00, oldPrice: 2890.00,
    image: "https://images.unsplash.com/photo-1511499767150-a48a237f0083?w=700&auto=format&fit=crop&q=80",
    description: "Titanyum alaşım çerçeve, Japan Nikon polarize Cr-39 cam, UV-400 koruma, tamamen ayarlanabilir burun yastığı ve kulak bacakları.",
    stock: 8, featured: false, isNew: true,
    rating: 4.7, reviews: 91
  },
  {
    id: 7,
    name: "Çift Duvarlı Paslanmaz Çelik Termos 750ml",
    category: "ev-yasam", categoryName: "Ev & Yaşam",
    price: 1290.00, oldPrice: 1590.00,
    image: "https://images.unsplash.com/photo-1517256064527-09c73fc73e38?w=700&auto=format&fit=crop&q=80",
    description: "Medical grade 316L paslanmaz çelik, vakum yalıtımı ile 18 saat sıcak / 36 saat soğuk, BPA-free sızdırmaz kapak, IPX7 suya dayanıklı.",
    stock: 22, featured: true, isNew: false,
    rating: 4.6, reviews: 428
  },
  {
    id: 8,
    name: "Akıllı LED Masa Lambası & Kablosuz Şarj",
    category: "ev-yasam", categoryName: "Ev & Yaşam",
    price: 2190.00, oldPrice: 2690.00,
    image: "https://images.unsplash.com/photo-1507473885765-e6ed057f782c?w=700&auto=format&fit=crop&q=80",
    description: "Sıfır titreşim LED panel, 2700K-6500K ayarlanabilir renk sıcaklığı, dokunmatik dimmer, 15W Qi kablosuz şarj istasyonu ve USB-C hızlı şarj çıkışı.",
    stock: 9, featured: false, isNew: true,
    rating: 4.8, reviews: 147
  }
];

// ==========================================================================
// 2. Sepet Yönetimi (localStorage)
// ==========================================================================
const CART_KEY = 'eshop_luxury_cart';

function getCart() {
  try { return JSON.parse(localStorage.getItem(CART_KEY) || '[]'); }
  catch { return []; }
}

function saveCart(cart) {
  localStorage.setItem(CART_KEY, JSON.stringify(cart));
  updateCartBadge();
}

function addToCart(productId, quantity = 1) {
  const product = sampleProducts.find(p => p.id === Number(productId));
  if (!product) return;

  const cart = getCart();
  const existing = cart.find(i => i.id === product.id);

  if (existing) {
    if (existing.quantity + quantity > product.stock) {
      showToast(`Üzgünüz, maksimum ${product.stock} adet ekleyebilirsiniz.`, 'warning');
      return;
    }
    existing.quantity += quantity;
  } else {
    cart.push({ id: product.id, name: product.name, price: product.price, image: product.image, quantity });
  }

  saveCart(cart);
  showToast(`"${product.name}" sepete eklendi!`, 'success');
}

function removeFromCart(productId) {
  saveCart(getCart().filter(i => i.id !== Number(productId)));
}

function updateCartQuantity(productId, qty) {
  const product = sampleProducts.find(p => p.id === Number(productId));
  const cart = getCart();
  const item = cart.find(i => i.id === Number(productId));
  if (!item) return;
  if (qty <= 0) { removeFromCart(productId); return; }
  if (product && qty > product.stock) {
    showToast(`Stok limiti: ${product.stock}`, 'warning');
    item.quantity = product.stock;
  } else {
    item.quantity = qty;
  }
  saveCart(cart);
}

function updateCartBadge() {
  const total = getCart().reduce((s, i) => s + i.quantity, 0);
  document.querySelectorAll('.cart-badge').forEach(b => {
    b.textContent = total;
  });
}

// Toast Bildirimi
function showToast(message, type = 'success') {
  let container = document.getElementById('toastContainer');
  if (!container) {
    container = document.createElement('div');
    container.id = 'toastContainer';
    container.className = 'toast-container position-fixed bottom-0 end-0 p-3';
    container.style.zIndex = '9999';
    document.body.appendChild(container);
  }

  const colors = {
    success: 'var(--navy)',
    warning: '#856404',
    error: '#dc3545'
  };
  const icons = { success: 'bi-check-circle-fill', warning: 'bi-exclamation-triangle-fill', error: 'bi-x-circle-fill' };

  const id = 'toast-' + Date.now();
  const html = `
    <div id="${id}" class="toast align-items-center border-0 text-white show"
         style="background: ${colors[type] || colors.success}; border-radius: 0.5rem; min-width: 280px; box-shadow: 0 8px 32px rgba(0,0,0,0.2);"
         role="alert" aria-live="assertive" aria-atomic="true">
      <div class="d-flex">
        <div class="toast-body d-flex align-items-center gap-2" style="font-size:0.875rem; font-weight:500;">
          <i class="bi ${icons[type] || icons.success}"></i>
          <span>${message}</span>
        </div>
        <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Kapat"></button>
      </div>
    </div>
  `;
  container.insertAdjacentHTML('beforeend', html);

  const el = document.getElementById(id);
  const bsToast = new bootstrap.Toast(el, { delay: 3000 });
  bsToast.show();
  el.addEventListener('hidden.bs.toast', () => el.remove());
}

// Para Formatlama
function formatCurrency(amount) {
  return new Intl.NumberFormat('tr-TR', { style: 'currency', currency: 'TRY', minimumFractionDigits: 2 }).format(amount);
}

// Yıldız Şablonu
function starsHTML(rating) {
  const full  = Math.floor(rating);
  const half  = rating % 1 >= 0.5 ? 1 : 0;
  const empty = 5 - full - half;
  return '<i class="bi bi-star-fill"></i>'.repeat(full)
       + (half ? '<i class="bi bi-star-half"></i>' : '')
       + '<i class="bi bi-star"></i>'.repeat(empty);
}

// İndirim Hesabı
function discountPercent(price, oldPrice) {
  if (!oldPrice) return 0;
  return Math.round((1 - price / oldPrice) * 100);
}

// Ürün Kart HTML Üretici
function createProductCardHTML(product) {
  const disc = discountPercent(product.price, product.oldPrice);
  let badgeHTML = '';
  if (product.isNew) badgeHTML = `<span class="product-badge badge-new">Yeni</span>`;
  else if (disc > 0) badgeHTML = `<span class="product-badge badge-sale">-%${disc}</span>`;

  return `
    <div class="col-sm-6 col-lg-4 mb-4">
      <div class="product-card card h-100 border-0">
        <div class="product-img-wrapper">
          <a href="product-detail.html?id=${product.id}" class="d-block h-100">
            <img src="${product.image}" alt="${product.name}" loading="lazy">
          </a>
          ${badgeHTML}
          <div class="product-actions-overlay">
            <button class="product-action-btn add-to-cart-btn" data-id="${product.id}" title="Sepete Ekle">
              <i class="bi bi-bag-plus"></i>
            </button>
            <button class="product-action-btn" title="Favorilere Ekle">
              <i class="bi bi-heart"></i>
            </button>
            <a href="product-detail.html?id=${product.id}" class="product-action-btn" title="İncele">
              <i class="bi bi-eye"></i>
            </a>
          </div>
        </div>
        <div class="card-body d-flex flex-column">
          <div class="product-cat-label">${product.categoryName}</div>
          <h3 class="mb-0">
            <a href="product-detail.html?id=${product.id}" class="product-title">${product.name}</a>
          </h3>
          <div class="product-rating">
            <span class="stars">${starsHTML(product.rating)}</span>
            <span class="review-count">(${product.reviews})</span>
          </div>
          <div class="product-pricing mt-auto">
            <span class="product-price">${formatCurrency(product.price)}</span>
            ${product.oldPrice ? `<span class="product-old-price">${formatCurrency(product.oldPrice)}</span>` : ''}
            ${disc > 0 ? `<span class="product-discount">-%${disc}</span>` : ''}
          </div>
          <button class="btn-add-cart add-to-cart-btn mt-2" data-id="${product.id}">
            <i class="bi bi-bag-plus"></i> Sepete Ekle
          </button>
        </div>
      </div>
    </div>
  `;
}

// ==========================================================================
// 3. DOMContentLoaded — Sayfa Başlatıcı
// ==========================================================================
document.addEventListener('DOMContentLoaded', () => {
  updateCartBadge();
  initNavbarScroll();

  // Arama formu yönlendirmesi
  document.querySelectorAll('form[id*="Search"]').forEach(form => {
    form.addEventListener('submit', e => {
      e.preventDefault();
      const q = form.querySelector('input[type="search"]')?.value.trim();
      if (q) window.location.href = `products.html?search=${encodeURIComponent(q)}`;
    });
  });

  // Ortak "Sepete Ekle" buton delegasyonu
  document.addEventListener('click', e => {
    const btn = e.target.closest('.add-to-cart-btn');
    if (btn) {
      e.preventDefault();
      addToCart(btn.getAttribute('data-id'), 1);
    }
  });

  // Sayfaya özel başlatıcılar
  initHomePage();
  initProductsPage();
  initDetailPage();
  initCartPage();
  initAuthPage();
});

// Navbar scroll efekti
function initNavbarScroll() {
  const navbar = document.querySelector('.luxury-navbar');
  if (!navbar) return;
  const onScroll = () => navbar.classList.toggle('scrolled', window.scrollY > 60);
  window.addEventListener('scroll', onScroll, { passive: true });
  onScroll();
}

// --------------------------------------------------------------------------
// Ana Sayfa
// --------------------------------------------------------------------------
function initHomePage() {
  const container = document.getElementById('featuredProductsContainer');
  if (!container) return;
  const featured = sampleProducts.filter(p => p.featured);
  container.innerHTML = featured.map(p => createProductCardHTML(p)).join('');
}

// --------------------------------------------------------------------------
// Ürün Listeleme (Filtre, Sıralama, Sayfalama)
// --------------------------------------------------------------------------
function initProductsPage() {
  const container = document.getElementById('productListContainer');
  if (!container) return;

  const urlParams   = new URLSearchParams(window.location.search);
  const initCat     = urlParams.get('category') || 'all';
  const initSearch  = urlParams.get('search') || '';

  const catRadios   = document.querySelectorAll('input[name="categoryFilter"]');
  const minPrice    = document.getElementById('minPriceInput');
  const maxPrice    = document.getElementById('maxPriceInput');
  const applyBtn    = document.getElementById('applyPriceFilter');
  const clearBtn    = document.getElementById('clearFilters');
  const sortSel     = document.getElementById('sortSelect');
  const pagination  = document.getElementById('paginationContainer');
  const countEl     = document.getElementById('productCountDisplay');

  if (initCat !== 'all') {
    const r = document.querySelector(`input[name="categoryFilter"][value="${initCat}"]`);
    if (r) r.checked = true;
  }

  let currentPage = 1;
  const PER_PAGE  = 6;

  function render() {
    const sel = document.querySelector('input[name="categoryFilter"]:checked')?.value || 'all';
    const min = parseFloat(minPrice?.value) || 0;
    const max = parseFloat(maxPrice?.value) || Infinity;
    const sort = sortSel?.value || 'default';

    let items = sampleProducts.filter(p => {
      const okCat    = sel === 'all' || p.category === sel;
      const okPrice  = p.price >= min && p.price <= max;
      const okSearch = !initSearch || p.name.toLowerCase().includes(initSearch.toLowerCase())
                                   || p.description.toLowerCase().includes(initSearch.toLowerCase());
      return okCat && okPrice && okSearch;
    });

    if (sort === 'price-asc')  items.sort((a, b) => a.price - b.price);
    if (sort === 'price-desc') items.sort((a, b) => b.price - a.price);
    if (sort === 'name-asc')   items.sort((a, b) => a.name.localeCompare(b.name, 'tr'));
    if (sort === 'rating')     items.sort((a, b) => b.rating - a.rating);

    if (countEl) countEl.textContent = `${items.length} ürün listeleniyor`;

    const total = Math.ceil(items.length / PER_PAGE) || 1;
    if (currentPage > total) currentPage = 1;
    const paged = items.slice((currentPage - 1) * PER_PAGE, currentPage * PER_PAGE);

    if (paged.length === 0) {
      container.innerHTML = `
        <div class="col-12 py-5 text-center">
          <i class="bi bi-search" style="font-size:3rem;color:var(--light-border);"></i>
          <h4 class="mt-3" style="font-family:'Playfair Display',serif;color:var(--navy);">Ürün Bulunamadı</h4>
          <p style="color:var(--muted);">Filtrelerinizi değiştirerek tekrar deneyebilirsiniz.</p>
        </div>`;
    } else {
      container.innerHTML = paged.map(p => createProductCardHTML(p)).join('');
    }

    if (pagination) renderPagination(total);
  }

  function renderPagination(total) {
    if (total <= 1) { pagination.innerHTML = ''; return; }
    let h = `<ul class="pagination justify-content-center mb-0">`;
    h += `<li class="page-item ${currentPage===1?'disabled':''}">
            <a class="page-link" href="#" data-page="${currentPage-1}">&laquo;</a></li>`;
    for (let i = 1; i <= total; i++) {
      h += `<li class="page-item ${currentPage===i?'active':''}">
              <a class="page-link" href="#" data-page="${i}">${i}</a></li>`;
    }
    h += `<li class="page-item ${currentPage===total?'disabled':''}">
            <a class="page-link" href="#" data-page="${currentPage+1}">&raquo;</a></li></ul>`;
    pagination.innerHTML = h;
  }

  catRadios.forEach(r => r.addEventListener('change', () => { currentPage=1; render(); }));
  applyBtn?.addEventListener('click', () => { currentPage=1; render(); });
  sortSel?.addEventListener('change', () => render());
  clearBtn?.addEventListener('click', () => {
    document.querySelector('input[name="categoryFilter"][value="all"]').checked = true;
    if (minPrice) minPrice.value = '';
    if (maxPrice) maxPrice.value = '';
    if (sortSel) sortSel.value = 'default';
    currentPage = 1; render();
  });
  pagination?.addEventListener('click', e => {
    const link = e.target.closest('.page-link');
    if (link && !link.parentElement.classList.contains('disabled')) {
      e.preventDefault();
      currentPage = parseInt(link.dataset.page);
      render();
      window.scrollTo({ top: 0, behavior: 'smooth' });
    }
  });

  render();
}

// --------------------------------------------------------------------------
// Ürün Detay
// --------------------------------------------------------------------------
function initDetailPage() {
  const container = document.getElementById('productDetailContainer');
  if (!container) return;

  const id = parseInt(new URLSearchParams(window.location.search).get('id')) || 1;
  const p = sampleProducts.find(x => x.id === id);

  if (!p) {
    container.innerHTML = `<div class="col-12 py-5 text-center">
      <h3 style="font-family:'Playfair Display',serif;color:var(--navy);">Ürün Bulunamadı</h3>
      <a href="products.html" class="btn-gold mt-3 d-inline-flex">Ürünlere Dön</a></div>`;
    return;
  }

  document.title = `${p.name} — EShopApp`;
  const disc = discountPercent(p.price, p.oldPrice);

  container.innerHTML = `
    <!-- Sol: Görsel -->
    <div class="col-lg-6 mb-4 mb-lg-0">
      <div class="detail-gallery-main">
        <img src="${p.image}" alt="${p.name}">
      </div>
    </div>

    <!-- Sağ: Detay -->
    <div class="col-lg-6">
      <div class="ps-lg-3">
        <!-- Breadcrumb -->
        <div class="luxury-breadcrumb mb-3">
          <a href="index.html">Ana Sayfa</a>
          <span class="separator">›</span>
          <a href="products.html">Ürünler</a>
          <span class="separator">›</span>
          <a href="products.html?category=${p.category}">${p.categoryName}</a>
        </div>

        <!-- Rozet -->
        <div class="detail-badge-area">
          <span class="detail-badge category">${p.categoryName}</span>
          <span class="detail-badge ${p.stock > 0 ? 'in-stock' : 'out-stock'}">
            <i class="bi bi-${p.stock > 0 ? 'check-circle' : 'x-circle'} me-1"></i>
            ${p.stock > 0 ? 'Stokta Var' : 'Tükendi'}
          </span>
          ${p.isNew ? `<span class="detail-badge in-stock">Yeni Ürün</span>` : ''}
        </div>

        <!-- Başlık -->
        <h1 style="font-family:'Playfair Display',serif;font-size:1.9rem;font-weight:700;color:var(--navy);line-height:1.25;margin-bottom:0.75rem;">
          ${p.name}
        </h1>

        <!-- Rating -->
        <div style="display:flex;align-items:center;gap:0.5rem;margin-bottom:1.25rem;">
          <span class="stars">${starsHTML(p.rating)}</span>
          <span style="font-size:0.9rem;font-weight:700;color:var(--navy);">${p.rating}</span>
          <span style="font-size:0.85rem;color:var(--muted);">(${p.reviews} değerlendirme)</span>
        </div>

        <!-- Fiyat -->
        <div class="detail-price-area">
          <span class="detail-price">${formatCurrency(p.price)}</span>
          ${p.oldPrice ? `<span class="detail-old-price">${formatCurrency(p.oldPrice)}</span>` : ''}
          ${disc > 0 ? `<span class="detail-discount-badge">%${disc} İndirim</span>` : ''}
        </div>

        <!-- Açıklama -->
        <p style="font-size:0.95rem;color:var(--muted);line-height:1.85;margin-bottom:1.75rem;">${p.description}</p>

        <!-- Adet & Sepete Ekle -->
        <div style="display:flex;gap:1rem;align-items:center;flex-wrap:wrap;margin-bottom:1.75rem;">
          <div class="quantity-picker">
            <button type="button" id="btnMinus" aria-label="Azalt">−</button>
            <input type="number" id="detailQty" value="1" min="1" max="${p.stock}">
            <button type="button" id="btnPlus" aria-label="Artır">+</button>
          </div>
          <button class="btn-add-to-cart-detail" id="btnDetailCart" ${p.stock <= 0 ? 'disabled' : ''}>
            <i class="bi bi-bag-plus"></i> Sepete Ekle
          </button>
          <button class="product-action-btn" title="Favorilere Ekle" style="width:48px;height:48px;border-radius:var(--radius-sm);">
            <i class="bi bi-heart"></i>
          </button>
        </div>

        <!-- Teslimat Bilgileri -->
        <ul class="detail-info-list">
          <li>
            <i class="bi bi-truck"></i>
            <div><strong>Ücretsiz Hızlı Kargo</strong><br>
              <span style="font-size:0.8rem;color:var(--muted);">500 TL üzeri siparişlerde aynı gün kargo</span></div>
          </li>
          <li>
            <i class="bi bi-shield-check"></i>
            <div><strong>2 Yıl Resmi Garanti</strong><br>
              <span style="font-size:0.8rem;color:var(--muted);">Yetkili servis ağı ile tam güvence</span></div>
          </li>
          <li>
            <i class="bi bi-arrow-repeat"></i>
            <div><strong>30 Gün İade Hakkı</strong><br>
              <span style="font-size:0.8rem;color:var(--muted);">Koşulsuz ve ücretsiz iade imkânı</span></div>
          </li>
          <li>
            <i class="bi bi-credit-card"></i>
            <div><strong>Taksitli Ödeme</strong><br>
              <span style="font-size:0.8rem;color:var(--muted);">12 aya varan taksit seçenekleri mevcuttur</span></div>
          </li>
        </ul>
      </div>
    </div>
  `;

  const qtyInput = document.getElementById('detailQty');
  document.getElementById('btnMinus')?.addEventListener('click', () => {
    const v = parseInt(qtyInput.value) || 1;
    if (v > 1) qtyInput.value = v - 1;
  });
  document.getElementById('btnPlus')?.addEventListener('click', () => {
    const v = parseInt(qtyInput.value) || 1;
    if (v < p.stock) qtyInput.value = v + 1;
    else showToast(`Maks. stok: ${p.stock}`, 'warning');
  });
  document.getElementById('btnDetailCart')?.addEventListener('click', () => {
    addToCart(p.id, parseInt(qtyInput.value) || 1);
  });
}

// --------------------------------------------------------------------------
// Sepet Sayfası
// --------------------------------------------------------------------------
function initCartPage() {
  const tbody = document.getElementById('cartTableBody');
  if (!tbody) return;

  function render() {
    const cart = getCart();
    const emptyEl   = document.getElementById('cartEmptyState');
    const contentEl = document.getElementById('cartContentState');

    if (cart.length === 0) {
      emptyEl?.classList.remove('d-none');
      contentEl?.classList.add('d-none');
      return;
    }
    emptyEl?.classList.add('d-none');
    contentEl?.classList.remove('d-none');

    let subtotal = 0;
    tbody.innerHTML = cart.map(item => {
      const line = item.price * item.quantity;
      subtotal += line;
      return `
        <tr>
          <td>
            <div class="d-flex align-items-center gap-3">
              <img src="${item.image}" alt="${item.name}" class="cart-product-img">
              <div>
                <a href="product-detail.html?id=${item.id}" class="cart-product-name">${item.name}</a>
                <span class="cart-product-meta">${formatCurrency(item.price)} / adet</span>
              </div>
            </div>
          </td>
          <td style="font-size:0.9rem;font-weight:600;color:var(--charcoal);">${formatCurrency(item.price)}</td>
          <td>
            <div class="quantity-picker">
              <button class="cart-qty-btn" data-id="${item.id}" data-action="decrease">−</button>
              <input class="cart-qty-input" type="number" data-id="${item.id}" value="${item.quantity}" min="1">
              <button class="cart-qty-btn" data-id="${item.id}" data-action="increase">+</button>
            </div>
          </td>
          <td style="font-weight:700;color:var(--navy);font-size:0.95rem;">${formatCurrency(line)}</td>
          <td class="text-end">
            <button class="product-action-btn cart-remove-btn" data-id="${item.id}" title="Kaldır">
              <i class="bi bi-trash3"></i>
            </button>
          </td>
        </tr>`;
    }).join('');

    const shipping  = subtotal > 0 && subtotal < 500 ? 49.90 : 0;
    const grandTotal = subtotal + shipping;

    const el = id => document.getElementById(id);
    if (el('cartSubtotal'))  el('cartSubtotal').textContent  = formatCurrency(subtotal);
    if (el('cartShipping'))  el('cartShipping').textContent  = shipping === 0 ? 'Ücretsiz' : formatCurrency(shipping);
    if (el('cartGrandTotal')) el('cartGrandTotal').textContent = formatCurrency(grandTotal);
  }

  tbody.addEventListener('click', e => {
    const removeBtn = e.target.closest('.cart-remove-btn');
    if (removeBtn) { removeFromCart(removeBtn.dataset.id); render(); return; }

    const qtyBtn = e.target.closest('.cart-qty-btn');
    if (qtyBtn) {
      const id = qtyBtn.dataset.id;
      const cart = getCart();
      const item = cart.find(i => i.id === Number(id));
      if (!item) return;
      const next = qtyBtn.dataset.action === 'increase' ? item.quantity + 1 : item.quantity - 1;
      updateCartQuantity(id, next);
      render();
    }
  });

  tbody.addEventListener('change', e => {
    const input = e.target.closest('.cart-qty-input');
    if (input) { updateCartQuantity(input.dataset.id, parseInt(input.value) || 1); render(); }
  });

  document.getElementById('checkoutBtn')?.addEventListener('click', () => {
    showToast('Siparişiniz alındı! Teşekkürler. (Demo)', 'success');
    localStorage.removeItem(CART_KEY);
    updateCartBadge();
    render();
  });

  render();
}

// --------------------------------------------------------------------------
// Giriş / Kayıt Formu Doğrulama
// --------------------------------------------------------------------------
function initAuthPage() {
  const emailRx = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

  function setValidity(input, valid, msg = '') {
    input.classList.toggle('is-invalid', !valid);
    input.classList.toggle('is-valid', valid);
    if (!valid) {
      let fb = input.parentElement.querySelector('.invalid-feedback');
      if (fb) fb.textContent = msg;
    }
  }

  document.getElementById('loginForm')?.addEventListener('submit', e => {
    e.preventDefault();
    const email = document.getElementById('loginEmail');
    const pass  = document.getElementById('loginPassword');
    let ok = true;

    if (!emailRx.test(email.value.trim())) { setValidity(email, false, 'Geçerli bir e-posta giriniz.'); ok = false; }
    else setValidity(email, true);

    if (pass.value.length < 6) { setValidity(pass, false, 'Şifre en az 6 karakter olmalıdır.'); ok = false; }
    else setValidity(pass, true);

    if (ok) { showToast('Giriş başarılı! Yönlendiriliyorsunuz...'); setTimeout(() => window.location.href = 'index.html', 1200); }
  });

  document.getElementById('registerForm')?.addEventListener('submit', e => {
    e.preventDefault();
    const name    = document.getElementById('registerName');
    const email   = document.getElementById('registerEmail');
    const pass    = document.getElementById('registerPassword');
    const confirm = document.getElementById('registerPasswordConfirm');
    const terms   = document.getElementById('registerTerms');
    let ok = true;

    if (!name.value.trim())                { setValidity(name,    false, 'Ad soyad gereklidir.'); ok = false; } else setValidity(name, true);
    if (!emailRx.test(email.value.trim())) { setValidity(email,   false, 'Geçerli bir e-posta giriniz.'); ok = false; } else setValidity(email, true);
    if (pass.value.length < 6)             { setValidity(pass,    false, 'Şifre en az 6 karakter olmalıdır.'); ok = false; } else setValidity(pass, true);
    if (confirm.value !== pass.value)      { setValidity(confirm, false, 'Şifreler eşleşmiyor.'); ok = false; } else setValidity(confirm, true);
    if (terms && !terms.checked)           { setValidity(terms,   false, 'Şartları kabul etmelisiniz.'); ok = false; } else if (terms) setValidity(terms, true);

    if (ok) {
      showToast('Hesabınız oluşturuldu!');
      const loginTab = document.getElementById('login-tab');
      if (loginTab) (bootstrap.Tab.getInstance(loginTab) || new bootstrap.Tab(loginTab)).show();
    }
  });
}
