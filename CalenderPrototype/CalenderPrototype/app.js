'use strict';
/**
 * Is a workspace where prototypes for the Calender functonality to be tested in
 */

class Event {
    date = Date.now();
    description = "Desc";
    users = new Set();
    owner;
    editers = new Set();
    endTime = new Date();
    //description = "Default Description";
    constructor(date, description, ...people) {
        this.date = date;
        this.description = description;
        for (const entry of people) {
            this.users.add(entry);
        }

        this.endTime.setTime(date.getTime() + this.hoursToMiliseconds(1));
    }
    setOwner(newOwner) {
        this.owner = newOwner;
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
        if (this.date != null) {
            output += this.date.toString() + '\n';
        }
        if (this.description != null) {
            output += this.description + '\n';
        }
        if (this.users != null) {
            for (const entry of this.users) {
                output += entry.toString() + '\n';
            }
        }
        if (this.owner != null) {
            output += this.owner.toString() + '\n';
        }
        if (this.editers != null) {
            for(const entry of this.editers) {
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
event.users.add(new Person("Alace", testUserID++, new Set()));
event.users.add(new Person("Bob", testUserID++, new Set()));
event.users.add(new Person("Charly", testUserID++, new Set()));
event.users.add(new Person("Denice", testUserID++, new Set()));
event.addEditer(new Person("Steve", testUserID++, new Set()));
for (let item of event.users) console.log(item.toString() +": " + item.userId);

console.log(event.toString());

