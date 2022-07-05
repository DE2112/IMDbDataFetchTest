import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-imdb-data',
  templateUrl: './imdb-data.component.html'
})
export class IMDBDataComponent {
  public movies: Movie[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Movie[]>(baseUrl + 'datafetch').toPromise().then(data => this.movies = data);
  }
}
interface Movie {
  title: string;
  //description: string;
  imageLink: string;
  rating: string;
}
