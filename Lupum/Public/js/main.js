$(document).ready(function () {


    $("#AddGroup").submit(function (ev) {
        ev.preventDefault();

        var group = {
            Name: $("input[name='Name']").val(),
            Roles: []
        };

        $(this).find(".action").each(function () {
            var role = {
                ActionId: $(this).data("id"),
                CanView: $(this).find("input[name='CanView']").is(":checked"),
                CanAdd: $(this).find("input[name='CanAdd']").is(":checked"),
                CanEdit: $(this).find("input[name='CanEdit']").is(":checked"),
                CanDelete: $(this).find("input[name='CanDelete']").is(":checked"),
                OwnerData: $(this).find("input[name='OwnerData']").is(":checked")
            };

            for (obj in role) {
                if (role[obj] === true) {
                    group.Roles.push(role);
                    break;
                }
            }
        });

        $.ajax({
            url: $(this).attr("action"),
            type: $(this).attr("method"),
            dataType: "json",
            data: {
                Group: group
            },
            success: function (response) {
                if (response.status === 200) {
                    $("#AddGroup")[0].reset();
                    toastr.success('Qrup Əlavə edildi');
                } else {
                    toastr.warning(response.message);
                }
            }
        });
        
    });

    $('a.delete').confirm({
        title: 'Ləğv etmək',
        content: 'Ləğv etməyə əminsiniz mi?',
        buttons: {
            "bəli": {
                btnClass: 'btn-danger',
                action: function () {
                    location.href = this.$target.attr('href');
                }
            },
            "xeyr": {
                btnClass: 'btn-success'
            }
        }
    });

});