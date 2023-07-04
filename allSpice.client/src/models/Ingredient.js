export class Ingredient {
    constructor(data) {
        this.id = data.Id
        this.name = data.name
        this.quantity = data.quantity
        this.recipeId = data.recipeId
    }
}