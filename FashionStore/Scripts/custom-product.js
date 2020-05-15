
$(function () {
    if ($('#tblProducts').length !== 0) {
        $('#tblProducts').dataTable({
            "scrollY": "700px",
            "scrollX": true
        });
    }

    if ($("#ckS").length !== 0) {
        $("#ckS").change(function () {
            if (!$(this).is(":checked")) {
                $("#SAmount").attr('readonly', true);
            } else {
                $("#SAmount").attr('readonly', false);

            }
        });
    }

    if ($("#ckXS").length !== 0) {
        $("#ckXS").change(function () {
            if (!$(this).is(":checked")) {
                $("#XSAmount").attr('readonly', true);
            } else {
                $("#XSAmount").attr('readonly', false);

            }
        });
    }

    if ($("#ckM").length !== 0) {
        $("#ckM").change(function () {
            if (!$(this).is(":checked")) {
                $("#MAmount").attr('readonly', true);
            } else {
                $("#MAmount").attr('readonly', false);

            }
        });
    }

    if ($("#ckL").length !== 0) {
        $("#ckL").change(function () {
            if (!$(this).is(":checked")) {
                $("#LAmount").attr('readonly', true);
            } else {
                $("#LAmount").attr('readonly', false);

            }
        });
    }

    if ($("#ckXL").length !== 0) {
        $("#ckXL").change(function () {
            if (!$(this).is(":checked")) {
                $("#XLAmount").attr('readonly', true);
            } else {
                $("#XLAmount").attr('readonly', false);

            }
        });
    }

    if ($("#ckXXL").length !== 0) {
        $("#ckXXL").change(function () {
            if (!$(this).is(":checked")) {
                $("#XXLAmount").attr('readonly', true);
            } else {
                $("#XXLAmount").attr('readonly', false);

            }
        });
    }

    if ($("#AddColor").length !== 0) {
        $(document).on("click", "#AddColor", function () {
            $("#AddColor").toggleClass("fa-plus").toggleClass("fa-minus");

        });
    }
});
