namespace BlazingPizza.Data{
    public class PizzaService{
        public async Task<Pizza[]> GetPizzasAsync(){
            return await Task.Run(() => (new List<Pizza>()
        {
            new Pizza { PizzaId = 1, Vegan= true, Vegetarian = true, Name = "The Baconatorizor", Price =  11.99M, Description = "It has EVERY kind of bacon", },
            new Pizza {PizzaId = 2, Vegan= true, Vegetarian = true, Name = "Buffalo chicken", Price =  12.75M, Description = "Spicy chicken, hot sauce, and blue cheese, guaranteed to warm you up"},
            new Pizza {PizzaId = 3, Vegan= true, Vegetarian = true, Name = "Veggie Delight", Price =  11.5M, Description = "It's like salad, but on a pizza"},
            new Pizza {PizzaId = 4, Vegan= true, Vegetarian = true, Name = "Margherita", Price =  9.99M, Description = "Traditional Italian pizza with tomatoes and basil"},
            new Pizza {PizzaId = 5, Vegan= true, Vegetarian = true, Name = "Basic Cheese Pizza", Price =  11.99M, Description = "It's cheesy and delicious. Why wouldn't you want one?"},
            new Pizza {PizzaId = 6, Vegan= true, Vegetarian = true, Name = "Classic pepperoni", Price =  10.5M, Description = "It's the pizza you grew up with, but Blazing hot!"}               
        }
            ).ToArray<Pizza>());
        }
    }
}