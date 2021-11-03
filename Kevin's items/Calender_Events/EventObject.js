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
     * @param {Date} startTime
     * @param {Date} endTime
     * @param {string} title
     * @param {string} description
     * @param {string} creator
     * @param {Set<string>} attendees
     * @param {Set<string>} tags
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
     * Changes given fields to
     * @param {Date} startTime
     * @param {Date} endTime
     * @param {string} title
     * @param {string} description
     * @param {string} creator
     * @param {Set<string>} attendees
     * @param {Set<string>} tags
     */
    edit(startTime = null, endTime = null, title = null, description = null, creator = null, attendees = null, tags = null){
        if (startTime != null) {
            this.startTime = startTime;
        }
        if (endTime != null) {

        }
        if (title != null) {

        }
        if (description != null) {

        }
        if (creator != null) {

        }
        if (attendees != null) {

        }
        if (tags != null) {

        }
    }
}