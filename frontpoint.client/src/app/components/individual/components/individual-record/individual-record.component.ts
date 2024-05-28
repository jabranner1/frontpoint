import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Individual } from '../../../../../api/models/individual';
import { NamePipe } from '../../../../pipes/name.pipe';
import { PhonePipe } from '../../../../pipes/phone.pipe';
import { AddressPipe } from '../../../../pipes/address.pipe';

@Component({
  selector: 'app-individual-record',
  standalone: true,
  imports: [CommonModule, NamePipe, PhonePipe, AddressPipe],
  templateUrl: './individual-record.component.html',
  styleUrl: './individual-record.component.scss',
})
export class IndividualRecordComponent {
  @Input({ required: true }) individual!: Individual;
}
