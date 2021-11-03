// JavaScript source code
'use strict';
class EventObject {
    startTime;
    endTime;
    title;
    description;
    creator;
    attendees = new Set();
    tags = new Set();


    /**
     * Constructs an EventObject with the given proproties
     * @param {Date} startTime The time the event will start
     * @param {Date} endTime The time the event will end
     * @param {string} title The title of the event
     * @param {string} description A description of the event
     * @param {string} creator The email address of the creator of the event
     * @param {Set<string>} attendees A set of strings of the emails of the people who will attend the event.
     * @param {Set<string>} tags The tags that are attached to the event.
     */
    constructor(startTime = Date.now, endTime = Date.now, title = "Event", description = "an event", creator = "Person", attendees = new Set(), tags = new Set()) {
        this.startTime = startTime;
        this.endTime = endTime;
        this.title = title;
        this.description = description;
        this.creator = creator
        for (i in attendees) {
            this.attendees.add(i);
        }
        for (i in tags) {
            this.tags.add(i);
        }
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
    edit(startTime = null, endTime = null, title = null, description = null, creator = null, attendees = null, tags = null){
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

    //TODO: ask how we should handle view.
    view() {
        throw "Method not implemented yet";
    }
}