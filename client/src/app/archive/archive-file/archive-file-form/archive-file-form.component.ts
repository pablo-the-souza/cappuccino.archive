import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { ArchiveService } from '../../archive.service';
import { Guid } from "guid-typescript";
import { Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-archive-file-form',
  templateUrl: './archive-file-form.component.html',
  styleUrls: ['./archive-file-form.component.css']
})
export class ArchiveFileFormComponent implements OnInit {
  update: string;
  selectedOption: Guid; 
  boxes: Observable<any>; 
  files : Observable<any>; 
  fileNewGuid: Guid;
  boxNewGuid: Guid;
  isUpdate: boolean; 
  

  constructor(public service: ArchiveService,
    @Inject(DOCUMENT) private _document: Document) {
      this.selectedOption = this.selectedOption;
      this.fileNewGuid = Guid.create();
      this.boxNewGuid = Guid.create();
  }

  refreshPage() {
    this._document.defaultView.location.reload();
  }

  ngOnInit(): void {
    this.resetForm();
    this.files = this.service.getFilesForForm();
    this.boxes = this.service.getBoxes();
  }

  onSubmit(form: NgForm) {
    this.isUpdate = this.service.isFileUpdate; 
     if (!this.isUpdate)
      {
        console.log("I'm Insert");
        this.insertFile(form)
      }
      
    else 
      this.updateFile(form)
  }

  insertFile(form: NgForm) {
    console.log("I'm insert file = " + form.value.boxId)
    this.service.postFile().subscribe(
      res => {
        this.resetForm(form);
        this.refreshPage()
        this.service.getFiles();
      },
      err => {
        console.log(err);
      }
    );
  }

  updateFile(form: NgForm) {
    this.service.putFile().subscribe(
      res => {
        console.log("Update ok")
        this.resetForm(form);
        this.service.getFiles();
      },
      err => {
        console.log(err);
        
      }
    );
  }

  insertBox(boxForm: NgForm){
    this.service.postBox().subscribe(
      res => {
        console.log("Box Inserted")
        this.boxes = this.service.getBoxes();
      },
      err => {
        console.log(err);
      }
    );
  }

  changeIsAddingBox(){
    // this.resetForm();

  }

  updateBox(event: any) {
    this.service.fileFormData.archiveBoxId = this.selectedOption.toString();
  }

  resetForm(form?: NgForm) {
    console.log(this.boxNewGuid)
    if (form != null)
      form.resetForm();

    this.service.fileFormData = {
      id: this.fileNewGuid.toString(),
      code: "",
      name: "",
      policyType: "",
      policyNumber: "",
      dateStart: "",
      dateEnd: "",
      comments: "",
      archiveBoxId: "" , 
    }
  }

}
