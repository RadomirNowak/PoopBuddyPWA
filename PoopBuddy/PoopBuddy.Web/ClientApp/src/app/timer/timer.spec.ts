import { TestBed, async, fakeAsync, tick } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { Timer } from './Timer';

describe("Timer",
  () => {

    it('fake',
      fakeAsync(() => {
        var timer = new Timer();
        console.log("Timer created");
        timer.start();
        tick(100);
        console.log("Test miliseconds:" + timer.time.miliSeconds);
        timer.stop();

      }));
  });
