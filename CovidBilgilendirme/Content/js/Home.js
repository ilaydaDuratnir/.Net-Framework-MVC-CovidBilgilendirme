$(document).ready(function () {
    $(".maske").hover(function () {
        $(".göster").toggle(1000);
    });
});

$(document).ready(function () {
    $("#symptomİmage").hover(function () {
        $(".hoverAlert").toggle();
        $(".ambulance").toggle(2000);
    })
})

$(document).ready(function () {
    $(".zoom").hover(function () {
        $(".rules").toggle(1000, function () {
            $(".rules1").toggle(1000);
            $(".rulesTitle").toggle(3000);
        });
    })

})
