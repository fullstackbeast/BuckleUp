var connection = new signalR.HubConnectionBuilder().withUrl("/quizHub").build();
const playerList = document.querySelector(".quizRoomPlayerList");

connection.start();

connection.on("receivemessage", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    let msgdetails = msg.split("-");

    let quizLink = window.location.pathname.split("/")[3];

    if(quizLink==msgdetails[1]){
        let playersInRoom = Array.from(playerList.children);
        let playerIntheRoom = playersInRoom.filter(player => player.textContent == msgdetails[0]);
        if(playerIntheRoom.length == 0){
            let li = document.createElement('li');
            li.textContent = msgdetails[0];
            playerList.appendChild(li);
        }
    }
});

connection.on("startquiz", function (message) {
    location.reload();
});
