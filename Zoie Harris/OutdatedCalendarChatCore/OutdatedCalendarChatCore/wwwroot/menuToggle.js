var menuButtons = document.querySelectorAll(".menu-column>*")
var menuBlocks = document.querySelectorAll(".center>*")

for (i of menuButtons) {
    i.addEventListener("click", onMenuButtonClick);
}

function onMenuButtonClick() {
    for (i = 0; i < menuBlocks.length; i++) {
        if (this == menuButtons[i]) {
            menuBlocks[i].style.display = "block";
        } else {
            menuBlocks[i].style.display = "none";
        }
    }
}

menuButtons[0].click();