import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Movie } from "../../models/movie";
import { PageEvent } from "@angular/material/paginator";

@Component({
  selector: 'imdb-data',
  templateUrl: './imdb-data.component.html'
})
export class IMDBDataComponent {
  public isDataLoaded: boolean = false;
  public movies: Movie[] = [];

  public length: number = 0;
  public pageSize: number = 10;
  public pageSizeOptions: number[] = [5, 10, 25, 100];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<PageData>(baseUrl + `datafetch/1/${this.pageSize}`)
      .subscribe(data => {
        this.length = data.count;
        this.movies = data.movies;
        this.isDataLoaded = true;
      });
  }

  onPageEvent(event: PageEvent) {
    this.isDataLoaded = false;

    this.http.get<PageData>(this.baseUrl + `datafetch/${event.pageIndex+1}/${event.pageSize}`)
      .subscribe(data => {
        this.movies = data.movies;
        this.isDataLoaded = true;
      });
  }
}
interface PageData {
  count: number;
  movies: Movie[];
}
