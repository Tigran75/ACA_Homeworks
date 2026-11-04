namespace Task2;

class Bonus {
    public int bonus = 5;
}

class Row {
    private int level;
    private Bonus bonus;

    public Row(int level, Bonus bonus) {
        this.level = level;
        this.bonus = bonus;
    }

    public int Calculate(int n) { 
        return n + level + bonus.bonus;
    }
}