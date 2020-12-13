import java.util.*;
import java.io.*;
/**
 * class for saving a list of telephone numbers
 * @author Anna Fischer
 * @version 1.2, 04.01.2012
 */

public class TelefonListe {
  // contains entries of the telephone list
	public static ArrayList<String> liste = new ArrayList<String> () ;
	private static BufferedReader bReader = new BufferedReader(new InputStreamReader(System.in));
	private static String dateiname;

	/*
	 * method to read the input of the user
	 */
	public static String inpString() {
		while (true) {
			try {
				return bReader.readLine();
			}
			catch (Exception e) {
				System.err.println("Eingabefehler!");
			}
		}
  	}

  	/*
  	 * Methode zum Hinzufuegen von Tastatureingaben in die Telefonliste,
  	 * wobei dies auch direkt in der main-Methode passieren kann.
  	 */
  	public static void addEintrag(String eintragS) {
		liste.add(eintragS);
	}

  	/*
  	 * Ausgabe aller Eintraege der Telefonliste.
  	 */
  	public static void printKomplett () {
		System.out.println ("Ihre Telefonliste:");
		for (Iterator i = liste.iterator () ; i.hasNext () ;) {
			System.out.print (i.next ());
			System.out.println ();
		}
	}

	/**
	 * Liest eine gespeicherte Telefonliste aus dem uebergebenen Dateinamen ein. Wird
	 * die Datei nicht gefunden wird der Benutzer um einen Dateinamen gebeten.
	 *
	 * @param file	Dateiname
	 */
	public static void einlesen(String file)  {
		try {
			// Drei Eingabestroeme erzeugen und mit der Datei verbinden:
			FileInputStream fiStream = new FileInputStream(dateiname);
			InputStreamReader isReader = new InputStreamReader(fiStream);
			BufferedReader bReader = new BufferedReader(isReader);
			// Alle Zeilen aus der Datei lesen und ausgeben
			String eineZeile;
			while (bReader.ready()) {
				eineZeile = bReader.readLine();
				liste.add(eineZeile);
			}
			// Eingabestrom schliessen
			bReader.close();
			System.out.println("Die Datei wurde gefunden.");
		}
		catch(IOException e) {
			System.out.println("Die angegebene Datei konnte nicht gefunden werden!");
			System.out.println("Ihr gewaehlter Dateiname (" + dateiname + ") wird nun zur Speicherung einer neuen Telefonliste verwendet.");
			System.out.println();
		}
    }

    /**
	 * Methode zum Schreiben von Text, der ueber die Tastatur eingegeben
	 * wird, in eine Datei.
	 *
	 * @param dateiName		name of the file where is input is written to
	 * @throws IOException	throws an exception if something faild with the input or output
	 */
	public static void schreibeTextInDatei(String dateiName) throws IOException {
		BufferedWriter bWriter = new BufferedWriter(new FileWriter(dateiName));
		System.out.println("Geben Sie einen Namen und eine Telefonnummer an (durch Leerzeichen getrennt): ");
		while(true) {
			String eintragS = inpString();
			addEintrag(eintragS);
			System.out.println("-> Wollen Sie einen weiteren Eintrag hinzufuegen? (J/N): ");
			String fortfahren = bReader.readLine();
			if(fortfahren.equals("J")) {
				System.out.println();
				System.out.println("Bitte geben Sie Ihren naechsten Eintrag an: ");
				continue;
			} else {
				System.out.println ();
				// ArrayList-Eintraege ueber Schleife in die Datei schreiben,
				// damit evtl. vorhandene Eintraege in bestehender Datei nicht ueberschrieben werden.
				for (int i = 0; i < liste.size(); i++) {
					bWriter.write(liste.get(i));
					bWriter.newLine();
				}
				// Puffer (Zwischenspeicher) leeren
				bWriter.flush();
				// Ausgabestrom wird geschlossen
				bWriter.close();
				break;
			}
		}
	}

	/** Testet und zeigt die Verwendung der Methoden */
	public static void main (String args []) throws IOException {
		System.out.println("Geben Sie bitte den Dateinamen (ohne Endung) an, in dem die Telefonliste gespeichert ist oder unter dem Sie die Telefonliste speichern wollen: ");
		dateiname = inpString()+".txt";
		einlesen(dateiname);
		System.out.println ();
		System.out.println("-> Wollen Sie nun (weitere) Eintraege in die Telefonliste hinzufuegen? (J/N): ");
		String fortfahren = bReader.readLine();
		if(fortfahren.equals("J")) {
			System.out.println ();
			schreibeTextInDatei(dateiname);
			System.out.println ();
			System.out.println("Ihre Liste sieht wie folgt aus und wurde gespeichert.");
			printKomplett();
		} else {
			System.out.println ();
			System.out.println("Folgende Eintraege konnten ermittelt werden.");
			printKomplett();
		}
  	}
}