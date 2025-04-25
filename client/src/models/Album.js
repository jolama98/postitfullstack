import { Profile } from "./Account.js"

export class Album {
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.title = data.title
    this.coverImg = data.coverImg
    this.archived = data.archived
    this.description = data.description
    this.category = data.category

    this.creator = new Profile(data.creator)
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.watcherCount = data.watcherCount
  }
}
