// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/// <reference path="../lib/signalr/browser/signalr.js" />
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(() => {
    let connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build();
    const countries = ["Russia", "USA", "Italy"];
    const genders = ["Male", "Female"];
    const editFootballer = "Footballer/EditFootballer/";
    const deleteFootballer = "Footballer/DeleteFootballer?footballerId=";

    connection.start();

    connection.on("refreshFootballers", function () {
        loadData();
    });

    loadData();
    function formatDate(dateStr) {
        return new Date(dateStr).toDateString();
    }
    function loadData() {
        var tr = '';

        $.ajax({
            url: '/Home/GetFootballers',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr = tr + `<tr>
                        <td>${v.firstName}</td>
                        <td>${v.lastName}</td>
                        <td>${v.teamName}</td>
                        <td>${countries[v.country]}</td>
                        <td>${formatDate(v.birthDate)}</td>
                        <td>${genders[v.gender]}</td>
                        <td>
                            <a href=${editFootballer+v.id}>Изменить
                        </a></td>
                        <td>
                            <a href=${deleteFootballer + v.id}>Удалить
                        </a></td>
                    </tr>`;
                });

                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.log(error);
            }
        });
    }
});