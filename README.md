# APBD - Ćwiczenie 8

Author: Robert Sendys

## Opis projektu

Aplikacja ASP.NET Core MVC do obsługi małej biblioteki uczelnianej.

Projekt wykorzystuje:

- ASP.NET Core MVC
- Entity Framework Core
- Code First
- SQL Server 2022
- Fluent API
- migracje EF Core
- seeding danych startowych

## Uruchomienie aplikacji

1. Sklonuj repozytorium:

```bash
git clone https://github.com/s29640/apbd-cw8-s29640.git
cd APBD-cw8-s29640
```

2. Przywróć zależności projektu:

```bash
dotnet restore
```

3. Skompiluj rozwiązanie:

```bash
dotnet build
```

4. Uruchom aplikację:

```bash
dotnet run --launch-profile https
```

5. Otwórz przeglądarkę i przejdź pod adres wyświetlony przez aplikację (domyślnie `https://localhost:7195`).

---

## Baza danych

Connection string znajduje się w pliku appsettings.json.

Domyślna nazwa bazy danych: APBD_cw8_s29640

Jeżeli chcesz użyć innej nazwy bazy danych, zmień wartość connection stringa w pliku appsettings.json.

Aby utworzyć bazę danych i zastosować wszystkie migracje, wykonaj polecenie:
```bash
dotnet ef database update
```

---

## Migracje

Migracja została utworzona komendą:
```bash
dotnet ef migrations add InitialCreate
```

Baza została utworzona/zaktualizowana komendą:
```bash
dotnet ef database update
```

Folder migracji: Migrations/

---

## DbContext

Własny kontekst bazy danych znajduje się w pliku:

Data/LibraryDbContext.cs

---

## Konfiguracja relacji

Relacje i ograniczenia bazy danych są skonfigurowane przez Fluent API w:
Data/LibraryDbContext.cs
Klasy pomocniczne:
Data/DbAuthors.cs
Data/DbBooks.cs
Data/DbBorrowings.cs

Relacje:

jeden autor ma wiele książek,
jedna książka ma wiele wypożyczeń,
wypożyczenie musi wskazywać książkę.

---

## Seeding danych

Dane startowe są dodane przez HasData w:

Data/LibraryDbContext.cs
Klasa pomocnicza:
Data/DbSeed.cs

---

## Odpowiedzi na pytania

### Co oznacza ORM i jaki problem rozwiązuje EF Core?

ORM (Object-Relational Mapping) to technika mapowania obiektów języka C# na tabele relacyjnej bazy danych. Entity Framework Core pozwala pracować na obiektach zamiast pisać ręcznie zapytania SQL, upraszczając dostęp do danych.

### Jaka jest rola DbContext?

`DbContext` jest główną klasą EF Core odpowiedzialną za komunikację z bazą danych. Zarządza encjami, śledzi ich zmiany oraz wykonuje zapytania i zapis danych.

### Czym DbSet różni się od zwykłej listy w C#?

`DbSet<T>` reprezentuje tabelę w bazie danych i umożliwia wykonywanie zapytań oraz operacji CRUD. W przeciwieństwie do `List<T>` dane nie są przechowywane wyłącznie w pamięci, lecz są pobierane i zapisywane w bazie danych.

### Dlaczego DbContext w aplikacji webowej powinien być Scoped?

`DbContext` powinien mieć cykl życia `Scoped`, ponieważ jedna jego instancja jest używana podczas obsługi pojedynczego żądania HTTP. Zapewnia to poprawne śledzenie zmian i bezpieczeństwo współbieżnego dostępu.

### Co robi migracja EF Core?

Migracja zapisuje zmiany modelu danych i umożliwia automatyczne utworzenie lub aktualizację struktury bazy danych bez ręcznego pisania skryptów SQL.

### Dlaczego seeding powinien być idempotentny?

Idempotentny seeding można wykonać wielokrotnie bez tworzenia duplikatów danych lub błędów. Dzięki temu inicjalizacja danych jest bezpieczna przy kolejnych uruchomieniach aplikacji.

### Kiedy Code First jest dobrym wyborem, a kiedy lepiej rozważyć Database First?

**Code First** jest dobrym wyborem podczas tworzenia nowych aplikacji, gdy model domenowy powstaje w kodzie i baza danych jest tworzona na jego podstawie.
**Database First** sprawdza się, gdy istnieje już gotowa baza danych, do której należy wygenerować model aplikacji.

W przypadku bardzo złożonych raportów, zapytań analitycznych lub operacji masowych (bulk insert/update) często lepszym rozwiązaniem jest użycie ręcznie napisanego SQL lub narzędzi takich jak SqlBulkCopy. W praktyce często stosuje się podejście hybrydowe – większość operacji CRUD realizowana jest przez EF Core, a najbardziej wymagające zapytania wykonywane są bezpośrednio w SQL.

---
