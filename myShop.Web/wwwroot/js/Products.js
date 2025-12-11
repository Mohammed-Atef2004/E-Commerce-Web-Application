$(document).ready(function () {

    var table = $("#mytable").DataTable({
        ajax: {
            url: "/Admin/Product/GetProducts",
            type: "GET",
            datatype: "json"
        },
        columns: [
            { data: "name" },
            { data: "description" },
            { data: "price" },
            { data: "categoryName" },
            {
                data: "id",
                render: function (id) {
                    return `
                        <a href="/Admin/Product/Edit/${id}" class="btn btn-sm btn-success me-1">
                            <i class="fa-solid fa-pen"></i>
                        </a>
                        <a href="/Admin/Product/Delete/${id}" class="btn btn-sm btn-danger">
                            <i class="fa-solid fa-trash"></i>
                        </a>
                    `;
                }
            }
        ],
        autoWidth: false,
        scrollX: true,

        // تمكين السحب وتغيير حجم الأعمدة
        colResize: {
            realtime: true
        },

        // التفاف النص تلقائيًا
        createdRow: function (row, data, dataIndex) {
            $('td', row).css('white-space', 'normal');
        }
    });

    // فلترة مخصصة: دمج البحث العام + dropdown الكاتيجوري
    $.fn.dataTable.ext.search.push(
        function (settings, data, dataIndex) {
            var selectedCategory = $('#categoryFilter').val();
            var category = data[3]; // عمود الكاتيجوري
            var searchTerm = $('#mytable_filter input').val().toLowerCase();

            var name = data[0].toLowerCase();
            var description = data[1].toLowerCase();
            var cat = category.toLowerCase();

            var matchesSearch = name.includes(searchTerm) || description.includes(searchTerm) || cat.includes(searchTerm);
            var matchesCategory = selectedCategory === "" || category === selectedCategory;

            return matchesSearch && matchesCategory;
        }
    );

    // إعادة رسم الجدول عند تغيير dropdown أو البحث العام
    $('#categoryFilter').on('change', function () {
        table.draw();
    });

    $('#mytable_filter input').on('keyup', function () {
        table.draw();
    });

});
