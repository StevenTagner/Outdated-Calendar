'use strict';
// JavaScript source code
class EventObject {
    startTime; //The time the event will start
    endTime; //The time the event will end
    title; //The title of the event
    description; //A description of the event
    creator; //The email address of the creator of the event
    attendees = new Set(); // A set of strings of the emails of the people who will attend the event.
    tags = new Set(); //The tags that are attached to the event.


    /**
     * Constructs an EventObject with the given proproties
     * @param {Date} startTime The time the event will start
     * @param {Date} endTime The time the event will end. Defaults to one hour after the event starts
     * @param {string} title The title of the event
     * @param {string} description A description of the event
     * @param {string} creator The email address of the creator of the event
     * @param {Set<string>} attendees A set of strings of the emails of the people who will attend the event.
     * @param {Set<string>} tags The tags that are attached to the event.
     */
    constructor(startTime = Date.now(), endTime = new Date(startTime + EventController.hoursToMiliseconds(1)), title = "Event", description = "an event", creator = "Person", attendees = new Set(), tags = new Set()) {
        this.startTime = startTime;
        this.endTime = endTime;
        this.title = title;
        this.description = description;
        this.creator = creator
        this.attendees = attendees;
        this.tags = tags;
    }

    /**
     * Changes given fields to what is given.
     * @param {Date} startTime The time the event will start
     * @param {Date} endTime The time the event will end
     * @param {string} title The title of the event
     * @param {string} description A description of the event
     * @param {string} creator The email address of the creator of the event
     * @param {Set<string>} attendees A set of strings of the emails of the people who will attend the event.
     * @param {Set<string>} tags The tags that are attached to the event.
     */
    edit(startTime = null, endTime = null, title = null, description = null, creator = null, attendees = null, tags = null) {
        if (startTime != null) {
            this.startTime = startTime;
        }
        if (endTime != null) {
            this.endTime = endTime;
        }
        if (title != null) {
            this.title = title;
        }
        if (description != null) {
            this.description = description;
        }
        if (creator != null) {
            this.creator = creator;
        }
        if (attendees != null) {
            this.attendees = attendees;
        }
        if (tags != null) {
            this.tags = tags;
        }
    }

    /**
     *
     *Returns a set of all emails assosiated with this event.
     */
    view() {
        var output = new Set();
        for (let i of this.attendees) {
            output.add(i);
        }
        output.add(this.creator);
        return output;
    }
}

class EventController {
    static valadate(startTime = undefined, endTime = undefined, title = undefined, description = undefined, creator = undefined, attendees = undefined, tags = undefined) {
        //Make sure event is valid and then create it.
        //throw "not implemented yet";

        //TODO: Make sure startTime is sooner than endTime
        if ((startTime != undefined && endTime != undefined) && startTime.getTime() > endTime.getTime()) {
            throw "Event must end after it begins";
        }
        /*
         * //Note: this causes issues because time passes while the program runs
        //TODO: make sure event does not occur in the past.
        if (startTime != undefined && (startTime.getTime() < Date.now.getTime())) {
            throw "Event must not start in the past";
        }
        */
        return this.createCalenderEvent(startTime, endTime, title, description, creator, attendees, tags);
    }


    /**
     * Constructs an EventObject with the given proproties and uploads the event to the database
     * @param {Date} startTime The time the event will start
     * @param {Date} endTime The time the event will end
     * @param {string} title The title of the event
     * @param {string} description A description of the event
     * @param {string} creator The email address of the creator of the event
     * @param {Set<string>} attendees A set of strings of the emails of the people who will attend the event.
     * @param {Set<string>} tags The tags that are attached to the event.
     */
    static createCalenderEvent(startTime = undefined, endTime = undefined, title = undefined, description = undefined, creator = undefined, attendees = undefined, tags = undefined) {

        //Create the event
        event = new EventObject(startTime, endTime, title, description, creator, attendees, tags);

        //TODO: Add event to database
        try {
            pushEventToDatabase(event);
        } catch (error) {
            console.error(error);
        }
        
        //Return the event.
        return event;
    }

    /**
     * Pushes the given event to the EventDatabase
     * @param {any} event the event to be pushed.
     */
    pushEventToDatabase(event) {
        throw "not implemented yet,";
    }

    /**
     * Converts a number of hours to miliseconds. To be used to allow an endTime to be <hours> hours later than a startTime. 
     * @param {any} hours The number of hours to be converted to miliseconds.
     */
    static hoursToMiliseconds(hours) {
        return hours * 3.6e+6;
    }

}

console.log(10);
var emails = new Set(["rddesign@gmail.com",
    "stakasa@verizon.net",
    "majordick@live.com",
    "amaranth@gmail.com",
    "ovprit@comcast.net",
    "harryh@comcast.net",
    "lbaxter@yahoo.com",
    "qmacro@yahoo.ca",
    "devphil@mac.com",
    "kdawson@sbcglobal.net",
    "errxn@yahoo.ca",
    "cmdrgravy@gmail.com"]);
var event = EventController.valadate(new Date(10), undefined, "new title", "new description", "testleader@gmail.com", emails, undefined);

console.log(event.view());
return;