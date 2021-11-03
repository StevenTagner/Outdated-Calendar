'use strict';
/**
 * Is a workspace where prototypes for the Calender functonality to be tested in
 */

class Event {
    startTime = Date.now();
    endTime = new Date();
    title = "title"
    description = "Desc";
    attendees = new Set();
    creator;
    editers = new Set();
    tags = new Set();
    //description = "Default Description";
    constructor(date, description, tags = "Event", ...people) {
        this.startTime = date;
        this.description = description;
        for (const entry of people) {
            this.attendees.add(entry);
        }
        for (const tag in tags) {
            this.tags.add(tag);
        }
        this.endTime.setTime(date.getTime() + this.hoursToMiliseconds(1));
    }

    setOwner(newOwner) {
        this.creator = newOwner;
    }
    setTitle(newTitle) {
        this.title = newTitle;
    }
    setDescription(newDescription) {
        this.description = newDescription;
    }
    setStartTime(newStartTime) {
        this.startTime = newStartTime;
    }
    setEndTime(newEndTime) {
        this.endTime = newEndTime;
    }
    addEditer(person) {
        this.editers.add(person);
    }

    hoursToMiliseconds(input) {
        return input * 3.6e+6;
    }
    getEventDate() {
        return date.get
    }

    toString() {
        var output = "";
        if (this.startTime != null) {
            output += this.startTime.toString() + '\n';
        }
        if (this.description != null) {
            output += this.description + '\n';
        }
        if (this.attendees != null) {
            for (const entry of this.attendees) {
                output += entry.toString() + '\n';
            }
        }
        if (this.creator != null) {
            output += this.creator.toString() + '\n';
        }
        if (this.editers != null) {
            for (const entry of this.editers) {
                output += entry.toString() + '\n';
            }
        }
        if (this.endTime != null) {
            output += this.endTime.toString() + '\n';
        }
        return output;
    }
}

function printUsers(s) {
    console.log(s.toString);
}
class Person {
    name = "Steve";
    userId = 0;
    //events is a Set of events a user is involved in. May want to make it a 
    events = new Set();
    constructor(name, userId, events) {
        this.name = name;
        this.userId = userId;
        this.events = events;
    }

    toString() {
        return this.name
    }
}

const event = new Event(new Date(), "A string");
var testUserID = 1;
event.attendees.add(new Person("Alace", testUserID++, new Set()));
event.attendees.add(new Person("Bob", testUserID++, new Set()));
event.attendees.add(new Person("Charly", testUserID++, new Set()));
event.attendees.add(new Person("Denice", testUserID++, new Set()));
event.addEditer(new Person("Steve", testUserID++, new Set()));
for (let item of event.attendees) console.log(item.toString() + ": " + item.userId);

console.log(event.toString());
return;

