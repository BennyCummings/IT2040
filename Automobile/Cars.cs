namespace Automobile;

public class Automobile{
    private string make;
    private string model;
    private string vin; 
    private string color;
    private int year;
    private AutoType autoType;

    public Automobile(string make, string model, int year, string vin, string color, AutoType autoType){
        this.autoType = autoType;
        this.make = make;
        this.model = model;
        this.vin = vin;
        this.color = color;
        this.year = year;
    }
    public AutoType getType(){
        return this.autoType;
    }
    public string getMake(){
        return this.make;
    }
    public string getModel(){
        return this.model;
    }
    public string getVin(){
        return this.vin;
    }
    public void setColor(string newColor){
        this.color = newColor;
    }
    public string getColor(){
        return this.color;
    }
    public int getYear(){
        return this.year;
    }
    public int getAutoAge(){
        return 2024 - this.year;
    }

}