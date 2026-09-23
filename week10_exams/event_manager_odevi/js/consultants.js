(function ($) {
    'use strict';

    function loadConsultants() {
        const consultantsContainer = $("#consultants-container");

        // Puanı yıldız ikonlarına çevirir (ör. 4.8 -> 5 yıldıza yakın)
        function renderStars(rating) {
            let stars = "";
            for (let i = 1; i <= 5; i++) {
                if (rating >= i) {
                    stars += '<i class="bi bi-star-fill"></i>';
                } else if (rating >= i - 0.5) {
                    stars += '<i class="bi bi-star-half"></i>';
                } else {
                    stars += '<i class="bi bi-star"></i>';
                }
            }
            return stars;
        }

        $.ajax({
            url: "data/consultants.json",
            method: "GET",
            dataType: "json"
        }).done(function (data) {
            consultantsContainer.empty();

            data.forEach(function (consultant) {
                const badgeClass =
                    consultant.status === 'Müsait' ? 'text-bg-success'
                        : consultant.status === 'Görevde' ? 'text-bg-warning'
                            : 'text-bg-secondary';

                const disabledClass = consultant.status !== 'Müsait' ? 'disabled' : '';

                const cardHTML = `
                    <div class="col-md-6 col-lg-4 mb-4">
                        <div class="card h-100">
                            <img src="${consultant.image}" alt="${consultant.name}" class="card-img-top">
                            <div class="card-body text-center">
                                <h5 class="card-title">${consultant.name}</h5>
                                <p class="card-text text-muted">${consultant.specialty}</p>
                                <p class="mb-1">Tecrübe: <strong>${consultant.experience} yıl</strong></p>
                                <p class="text-gold mb-2">
                                    ${renderStars(consultant.rating)}
                                    <span class="text-dark ms-1">${consultant.rating.toFixed(1)}</span>
                                </p>
                                <span class="badge ${badgeClass}">${consultant.status}</span>
                            </div>
                            <div class="card-footer border-0 bg-transparent text-center">
                                <a href="reservation.html" class="btn btn-gold btn-sm w-100 ${disabledClass}">Etkinlik Planla</a>
                            </div>
                        </div>
                    </div>
                `;
                consultantsContainer.append(cardHTML);
            });
        }).fail(function (error) {
            console.error('HATA: ', error);
            consultantsContainer.html(`
                <div class="col-12">
                    <div class="alert alert-danger">
                        Danışman verileri yüklenemedi. Bağlantınızı ve data/consultants.json dosyasını kontrol ediniz.
                    </div>
                </div>
            `);
        });
    }

    $(function () {
        loadConsultants();
    });
})(jQuery);