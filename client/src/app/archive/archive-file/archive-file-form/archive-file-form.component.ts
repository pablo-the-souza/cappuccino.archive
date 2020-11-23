import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { ArchiveService } from '../../archive.service';
import { Guid } from "guid-typescript";

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
  isAddingBox: boolean; 
  fileNewGuid: Guid;
  boxNewGuid: Guid;
  

  constructor(public service: ArchiveService) { 
      this.fileNewGuid = Guid.create();
      this.boxNewGuid = Guid.create();
      
  }

  ngOnInit(): void {
    this.isAddingBox = false; 
    this.resetForm();
    this.files = this.service.getFilesForForm();
    this.boxes = this.service.getBoxes();
    

    this.service.boxFormData = {
      id: this.boxNewGuid.toString(), 
      name: "",
      code: ""
    }
    console.log("I'm box form data id = " + this.service.boxFormData.id)
  }

  onSubmit(form: NgForm) {
    console.log(form.value)
    if (this.service.fileFormData.id == "")
      this.insertFile(form)
    else 
      this.updateFile(form)
  }

  insertFile(form: NgForm) {
    console.log("I'm boxID = " + form.value.boxId)
    this.service.postFile().subscribe(
      res => {
        this.resetForm(form);
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
    this.isAddingBox = false; 
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
    this.isAddingBox = true; 
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
      name: "",
      code: "",
      value: 0,
      archiveBoxId: "" , 
    }
  }

}
