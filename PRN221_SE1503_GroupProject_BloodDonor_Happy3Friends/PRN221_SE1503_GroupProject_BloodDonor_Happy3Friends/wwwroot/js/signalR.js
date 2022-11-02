"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

/*$(() => {
    LoadAppUserData();
    LoadPosts();
    LoadPostsForAll();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();

    connection.on("LoadAppUsers", function () {
        LoadAppUserData();
    })
    LoadAppUserData();

    function LoadAppUserData() {
        var tr = '';
        $.ajax({
            url: '/AppUsers/GetAppUsers',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `<tr>
                        <td> ${v.fullName} </td>
                        <td> ${v.address} </td>
                        <td> ${v.email} </td>
                        <td> ${v.password} </td>
                        <td>
                <a href='../AppUsers/Edit/${v.userId}'>Edit</a> |
                <a href='../AppUsers/Details/${v.userId}'>Details</a> |
                <a href='../AppUsers/Delete/${v.userId}'>Delete</a> |
                </td> </tr>`
                })
                $("#tableAppUser").html(tr);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }

    connection.on("LoadPosts", function () {
        LoadPosts();
    })
    LoadPosts();

    function LoadPosts() {
        var tr = '';
        $.ajax({
            url: '/Posts/GetPosts',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    var createdDate = new Date(v.createdDate);
                    var updatedDate = new Date(v.updatedDate);
                    tr += `<tr>
                        <td> ${v.title} </td>
                        <td> ${v.content} </td>
                        <td> ${v.author.fullName} </td>
                        <td> ${v.category.categoryName} </td>
                        <td> ${createdDate.getDate() + '/' + (createdDate.getMonth() + 1) + '/' + createdDate.getFullYear() + ' - ' + createdDate.getHours() + ':' + createdDate.getMinutes()} </td>
                        <td> ${v.updatedDate != null ? (updatedDate.getDate() + '/' + (updatedDate.getMonth() + 1) + '/' + updatedDate.getFullYear() + ' - ' + updatedDate.getHours() + ':' + updatedDate.getMinutes()) : ' '} </td>
                        <td> 
                            ${(v.publishStatus == true) ? `<input type="checkbox" checked disabled/>` : `<input type="checkbox" disabled/>`}
                        </td>
                        <td>
                <a href='../Posts/Edit/${v.postId}'>Edit</a> |
                <a href='../Posts/Details/${v.postId}'>Details</a> |
                <a href='../Posts/Delete/${v.postId}'>Delete</a> |
                </td> </tr>`
                })
                $("#tablePosts").html(tr);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }

    connection.on("LoadPostsForAll", function () {
        LoadPostsForAll();
    })
    LoadPostsForAll();

    function LoadPostsForAll() {
        var tr = '';
        $.ajax({
            url: '/Home/GetPostsForAll',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    var createdDate = new Date(v.createdDate);
                    var updatedDate = new Date(v.updatedDate);
                    tr += `<tr>
                        <td> ${v.title} </td>
                        <td> ${v.content} </td>
                        <td> ${v.author.fullName} </td>
                        <td> ${v.category.categoryName} </td>
                        <td> ${createdDate.getDate() + '/' + (createdDate.getMonth() + 1) + '/' + createdDate.getFullYear() + ' - ' + createdDate.getHours() + ':' + createdDate.getMinutes()} </td>
                        <td> ${v.updatedDate != null ? (updatedDate.getDate() + '/' + (updatedDate.getMonth() + 1) + '/' + updatedDate.getFullYear() + ' - ' + updatedDate.getHours() + ':' + updatedDate.getMinutes()) : ' '} </td >
                        <td>
                            <a href='../Posts/Details/${v.postId}'>Details</a>
                        </td> 
                            </tr>`
                })
                $("#tablePostsForAll").html(tr);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }
})*/