import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Books } from './books.model';
import { BooksService } from './books.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css'],
})
export class BooksComponent implements OnInit, AfterViewInit {
  booksData: Books[] = [];
  desplegarColumnas: string[] = ['titulo', 'descripcion', 'autor', 'precio'];
  dataSource: MatTableDataSource<Books> = new MatTableDataSource<Books>();
  @ViewChild(MatSort) ordenamiento!: MatSort;
  @ViewChild(MatPaginator) paginacion!: MatPaginator;

  constructor(private booksService: BooksService) {}
  ngAfterViewInit(): void {
    this.dataSource.sort = this.ordenamiento;
    this.dataSource.paginator = this.paginacion;
  }

  ngOnInit(): void {
    this.booksData = this.booksService.books;
    this.dataSource.data = this.booksData;
  }
  filter(event: Event) {
    if (event) {
      this.dataSource.filter = (event.target as HTMLInputElement)?.value;
    }
  }
}
