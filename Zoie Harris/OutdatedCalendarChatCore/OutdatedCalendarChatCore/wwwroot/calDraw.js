//Script to set up a dynamic calendar

//this part sets up some important calendar information
var currDate = new Date();
// currDate = new Date(2026, 10, 30);

var monthDayCount = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

//populate the calendar with cells, each with a section for day number and events
var calTable = document.querySelector(".calendar>table")
for(let i = 2; i <= 7; i++) {
    var row = calTable.insertRow(i);
    for(let j = 0; j <= 6; j++) {
        var cell = row.insertCell();
        var dayDiv = document.createElement("div");
        var eventDiv = document.createElement("div");

        cell.appendChild(dayDiv);
        cell.appendChild(eventDiv);

        dayDiv.style.border = "none";
        dayDiv.style.height = "1em";
        dayDiv.style.paddingRight = ".25em";
        dayDiv.style.paddingTop = ".25em";
        eventDiv.style.border = "none";
        eventDiv.style.height = "calc(100% - 1.25em + 1px)";
    }
}

var daysArr = document.querySelectorAll(".calendar td");
setCalendar();

//attach appropriate listeners to forward/back buttons
document.querySelector(".calendar .month :last-child").addEventListener("click", onNextMonthClick);
document.querySelector(".calendar .month :first-child").addEventListener("click", onLastMonthClick);



function setCalendar() {
    //setting the current month at the top of the calendar
    document.querySelectorAll(".month > *")[1].innerHTML = new Intl.DateTimeFormat('en-US', {month: 'long', year: 'numeric'}).format(currDate);
    
    //determining which day of the week the first of the month falls on
    var currMonthStart = currDate.getDay();
    var currMonthOffset = currDate.getDate() % 7;
    while(currMonthOffset > 0) {
        currMonthStart--;
        currMonthOffset--;
    }
    if(currMonthStart < 0) {
        currMonthStart += 7;
    }

    //adjust for a leap year
    if(currDate.getFullYear() % 4 == 0 && currDate.getFullYear() % 100 != 0 ||
    currDate.getFullYear() % 400 == 0) {
    monthDayCount[1] = 29;
    }   

    //remove current stuff attached to all days
    daysArr.forEach((x) => {
        x.childNodes[1].innerHTML = "";
        x.childNodes[0].innerHTML = "";
        x.removeEventListener("click", onDayClick)
    });
    
    //adding in day numbers + event listeners
    for(let i = currMonthStart; i < monthDayCount[currDate.getMonth()] + currMonthStart; i++) {
        daysArr[i].childNodes[0].innerHTML = (i - currMonthStart + 1).toString();
        daysArr[i].addEventListener("click", onDayClick);

        //ajax request:
        // var xhr= new XMLHttpRequest();
        // xhr.onreadystatechange = function() {  
        //     var DONE = 4; // readyState 4 means the request is done.
        //     var OK = 200; // status 200 is a successful return.               
        //     if (xhr.readyState === DONE) { 
        //         if (xhr.status === OK) {
        //             console.log(xhr.responseText);
        //             if(xhr.responseText != "") {
        //                 //
        //             } else {
        //                 alert("Something has gone wrong!")
        //             }
        //         } else {
        //             console.log('Error: ' + xhr.status);
        //         }
        //     }
        // }

        // //TODO: get all the fields we need to query the database for each day's events
        //     //we might want to put this outside the for-loop so each month only gets one query for all the events
        // // var queryString = "?table=" + this.parentElement.getAttribute("name");
        // // for(i of currFields) {
        // //     queryString += ("&" + i.getAttribute("placeholder") + "=" + escape(i.value));
        // // }

        // console.log(queryString);

        // //TODO: rename the php file to whatever we use
        // //xhr.open("GET", "insert.php" + queryString, true);
        // xhr.send();   

    }
}

function onNextMonthClick() {
    if(currDate.getMonth() == 11) {
        currDate.setMonth(0);
        currDate.setFullYear(currDate.getFullYear() + 1);
    } else {
        currDate.setMonth(currDate.getMonth() + 1);
    }

    setCalendar();
}

function onLastMonthClick() {
    if(currDate.getMonth() == 0) {
        currDate.setMonth(11);
        currDate.setFullYear(currDate.getFullYear() - 1);
    } else {
        currDate.setMonth(currDate.getMonth() - 1);
    }

    setCalendar();
}

function onDayClick() {
    //PLACEHOLDER FOR EVENT VIEWING FUNCTIONALITY
    console.log(this.childNodes[0].innerHTML);
}