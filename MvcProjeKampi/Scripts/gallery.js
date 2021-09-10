var $container = $('#img-grid');
var $boxes = $('.img-item');
$boxes.hide();

Fancybox.bind('[data-fancybox="gallery"]', {
    l10n: {
        CLOSE: "Kapat",
        NEXT: "Sonraki",
        PREV: "Önceki",
        MODAL: "Bu içeriği ESC tuşu ile kapatabilirsiniz.",
        ERROR: "Bir şeyler yanlış gitti, lütfen daha sonra tekrar deneyin",
        IMAGE_ERROR: "Görsel bulunamadı",
        ELEMENT_NOT_FOUND: "HTML öğesi bulunamadı",
        AJAX_NOT_FOUND: "AJAX yükleme hatası: Bulunamadı",
        AJAX_FORBIDDEN: "AJAX yükleme hatası: Yasak",
        IFRAME_ERROR: "Sayfa yükleme hatası",
        TOGGLE_ZOOM: "Yakınlaştırma seviyesini değiştir",
        TOGGLE_THUMBS: "Küçük resimleri aç/kapat",
        TOGGLE_SLIDESHOW: "Slayt gösterisini aç/kapat",
        TOGGLE_FULLSCREEN: "Tam ekran modunu değiştir",
        DOWNLOAD: "İndir"
    }
});

$(document).ready(function () {
    $container.imagesLoaded(function () {
        $boxes.fadeIn();
        $container.masonry({
            itemSelector: '.img-item',
            percentPosition: true,
            isAnimated: !Modernizr.csstransitions
        });
    });
});
