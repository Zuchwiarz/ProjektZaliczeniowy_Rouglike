namespace GrTypuRouglike;

public class Map
{
    private Cell[][] _cells; // tablica tablic, czarnoksięstwo
    
    //WCZYTYWANIE MAPY Z PLIKU
    //i nakładanie na nią tablicy tablic _cells;
    public void LoadFromFile(string path) 
    {
        string[] lines = File.ReadAllLines(path);
        // ^^ otwiera plik > czyta go w całości linijka po linijce > zamyka
        
        _cells = new Cell[lines.Length][];
        // ^ tworzymyy pierwszątablicę o długości równej ilości wierszy w pliku

        for (var rowIndex = 0; rowIndex < lines.Length; rowIndex++)
        {
            //^ przelatujemy przez każdą linijkę
            
            var line = lines[rowIndex]; // numerujemy linijki, jedna linijka jest teraz zmienną
            _cells[rowIndex] = new Cell[line.Length]; 
            //^na każdym numerze tworzymy tablicę Cells, równą długości linijki
            Cell[] row = _cells[rowIndex];
            //^ kompletnie nie rozumiem
            //
            for (var columnIndex = 0; columnIndex < line.Length; columnIndex++)
            {
                var character = line[columnIndex];
                row[columnIndex] = new Cell();
                row[columnIndex].Visuals = character;
                // dobra, chyba rozumiem
                // tworzymy osobną Cell (całą tablicę) na każdą linijkę kodu, równą dłógości linijki
                // a potem w tej linijko-tablicy przypisujemy każdą komórkę, zgodnie z charterem w pliku
                // tworząc przy tym new Cells() i wsadzamy je w oczka tablicy row (oczka to kolumny)
                // Bożeeeeee...
            }
        }
        // to chyba najtrudniejsza rzecz ze wszystkich na tym programowaniu
    }

    public void Display()
    {
        //DRUKOWANIE MAPY
        Console.SetCursorPosition(0, 0);
        foreach (var row in _cells)
        {
            foreach (var cell in row)
            {
                cell.Display();
            }
            Console.WriteLine(); //< *dzyń* nowa linijka, jak w maszynie do pisania
        }
    }// za każą komórkę w każdej linijce, displayiujemy komórkę

    //ZNAJDŹ KOMÓRKĘ konkretną
    public Cell GetCell(int x, int y)
    {
        return _cells[y][x];
    }

    //WYSOKOŚĆ MAPY
    public int GetHeight()
    {
        return _cells.Length;
        // mam rozumieć że długością tablicy tablic jest tylko ten pierwszy []? no dobra
    }
    //SZEROKOŚĆ MAPY (konkretnie jednej linijki, mapa może mieć kształ fikuśny)
    public int GetRowWidth(int row)
    {
        return _cells[row].Length;
    }
}