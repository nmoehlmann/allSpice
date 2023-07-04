export class Recipe {
    constructor(data) {
        this.id = data.Id
        this.title = data.title
        this.instructions = data.instructions
        this.category = data.category
        this.img = data.img
        this.creatorId = data.creatorId
        this.creator = data.creator
    }
}