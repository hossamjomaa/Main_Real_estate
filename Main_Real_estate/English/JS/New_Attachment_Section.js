document.getElementById("newsectionbtn").onclick = function() {
    var container = document.getElementById("container");
    var section = document.getElementById("mainsection");
    container.appendChild(section.cloneNode(true));
}