$(function () {
    // Formül: Temel Paket + (Konuk Sayısı × Kişi Başı Ücret) + Ek Hizmetler
    const events = {
        wedding: { base: 15000, perGuest: 250 },
        conference: { base: 20000, perGuest: 300 },
        birthday: { base: 5000, perGuest: 150 },
        engagement: { base: 10000, perGuest: 200 }
    };
    const fmt = n => n.toLocaleString("tr-TR") + " ₺";

    // Geçmiş tarihleri engelle (sv-SE yerel ayarı YYYY-MM-DD biçimi verir)
    $("#eventDate").attr("min", new Date().toLocaleDateString("sv-SE"));

    // Ana sayfadan gelen ?type=wedding parametresini seç
    const type = new URLSearchParams(location.search).get("type");
    if (events[type]) $("#eventType").val(type);

    function calculate() {
        const ev = events[$("#eventType").val()];
        const guests = Math.min(parseInt($("#guests").val(), 10) || 0, 500);
        let total = ev ? ev.base + guests * ev.perGuest : 0;
        const costly = [];

        $(".extra:checked").each(function () {
            total += $(this).data("price");
            if ($(this).data("costly")) costly.push($(this).data("name"));
        });

        // Ek maliyet uyarısı
        $("#costlyList").text(costly.join(" ve "));
        $("#costAlert").toggleClass("d-none", costly.length === 0);

        // Toplam ve bütçe karşılaştırması
        const budget = Number($("#budget").val());
        $("#total").text(fmt(total));
        $("#budgetNote").text(budget && total > budget ? "Bütçenizi " + fmt(total - budget) + " aşıyor." : "");
        return total;
    }

    $("#reservationForm").on("input change", calculate).on("submit", function (e) {
        e.preventDefault();
        this.classList.add("was-validated");
        if (!this.checkValidity()) return;

        $("#sName").text($("#fullName").val().trim());
        $("#sType").text($("#eventType option:selected").text());
        $("#sDate").text(new Date($("#eventDate").val()).toLocaleDateString("tr-TR"));
        $("#sTotal").text(fmt(calculate()));
        bootstrap.Modal.getOrCreateInstance("#summaryModal").show();
    });

    // Modal kapanınca formu sıfırla
    $("#summaryModal").on("hidden.bs.modal", function () {
        $("#reservationForm").removeClass("was-validated")[0].reset();
        calculate();
    });

    calculate();
});