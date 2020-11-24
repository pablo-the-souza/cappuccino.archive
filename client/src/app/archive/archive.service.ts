import { Injectable } from '@angular/core';
import { File } from '../models/file.model';
import { Box } from '../models/box.model';

import { HttpClient, HttpHeaders } from "@angular/common/http";
import { MatTableDataSource } from '@angular/material/table';
import { Observable, Subscription } from 'rxjs';




@Injectable({
  providedIn: 'root'
})
export class ArchiveService {
  isBoxUpdate: boolean; 
  isFileUpdate: boolean
  fileFormData: File;
  boxFormData: Box; 
  
  ELEMENT_DATA: File[] = []
  BOX_ELEMENT_DATA: Box[] = []

  filesDataSource = new MatTableDataSource<File>(this.ELEMENT_DATA);
  boxesDataSource = new MatTableDataSource<Box>(this.BOX_ELEMENT_DATA);

  readonly rootURL = 'https://localhost:5001/api'; 

  private fbSubs: Subscription[] = [];

  constructor(private http: HttpClient) { }

  postFile() {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.post(this.rootURL + '/files', this.fileFormData, httpOptions)
  }

  putFile() {
    return this.http.put(
      this.rootURL + '/files/' + this.fileFormData.id,
      this.fileFormData)
  }

  putBox() {
    return this.http.put(
      this.rootURL + '/boxes/' + this.boxFormData.id,
      this.boxFormData)
  }

  deleteFile(id) {
    return this.http.delete(
      this.rootURL + '/files/' + id,
    )
  }

  deleteBox(id) {
    return this.http.delete(
      this.rootURL + '/boxes/' + id,
    )
  }

  public getFiles() {
    return this.http.get(this.rootURL + '/files').toPromise()
      .then(files => this.filesDataSource.data = files as File[])
  }

  public getFilesForForm() {
    return this.http.get<any>(this.rootURL + '/files') 
  }

  public getBoxes() {
    return this.http.get<any>(this.rootURL + '/boxes')
  }

  public getBoxesForList() {
    return this.http.get<any>(this.rootURL + '/boxes').toPromise()
    .then(boxes => this.boxesDataSource.data = boxes as Box[])
  }

  postBox() {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.post(this.rootURL + '/boxes', this.boxFormData, httpOptions)
  }

  cancelSubscriptions() {
    this.fbSubs.forEach(sub => sub.unsubscribe());
  }

}
// ngOnInit(): void {
//   forkJoin([this.data.getUsers(), this.otherData.getUnitAssignments()])
//       .subscribe(result => {
//           this.firstRequestResult = result[0];
//           this.secondRequestResult = result[1];
//           //building your dataSource here

//       });
// }