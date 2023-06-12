function HienThiAnh(anhtailen, anhhientthi) {
    if (anhtailen.files && anhtailen.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(anhhientthi).attr('src', e.target.result);
        }
        reader.readAsDataURL(anhtailen.files[0]);
    }
}