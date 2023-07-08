export class Recipe {
    constructor(data) {
        this.id = data.id
        this.title = data.title
        this.instructions = data.instructions
        this.category = data.category
        this.img = data.img
        this.creatorId = data.creatorId
        this.creator = data.creator
    }
}

export class SubscriptionRecipe extends Recipe{
    constructor(data){
        super(data)
        this.subscriptionId = data.subscriptionId
    }
}