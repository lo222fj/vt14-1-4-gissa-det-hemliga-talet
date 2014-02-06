"use strict";
window.onload = setFocusAndMark;

function setFocusAndMark() {
    var input = document.getElementById("GuessTextBox");
    input.focus();
    input.select();
}